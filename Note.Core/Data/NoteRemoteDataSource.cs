using Note.Core.Utility;
using Note_3.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Note.Core.Data
{
    public class NoteRemoteDataSource
    {
        public static readonly HttpClient client = new HttpClient();

        public NoteRemoteDataSource()
        {
            client.BaseAddress = new Uri("http://localhost:5042/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<NotesDTO> GetNotes(int id)
        {
            NotesDTO notes = null;

            HttpResponseMessage response = await client.GetAsync($"api/Notes/{id}");
            if (response.IsSuccessStatusCode)
            {
                notes = DataSerializer.Deserialize<NotesDTO>(
                   await response.Content.ReadAsStringAsync());
            }
            return notes;
        }
        public async Task<List<NotesDTO>> GetNotesList()
        {

            HttpResponseMessage response = await client.GetAsync(
                "api/Notes");
            response.EnsureSuccessStatusCode();

            List<NotesDTO> notesResponse = new List<NotesDTO>();
            if (response.IsSuccessStatusCode)
            {
                notesResponse = DataSerializer.Deserialize<List<NotesDTO>>(
                    await response.Content.ReadAsStringAsync());
            }
            return notesResponse;
        }

        public async Task PostNotes(AddNotesDTO addNotesDTO)
        {
            HttpResponseMessage response = await client.PostAsync(
                ("api/Notes"), JsonContent.Create(addNotesDTO));

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Добавление завершилось с ошибкой!");
            }
            return;
        }
        public async Task PutNotes(UpdateNotesDTO notes)
        {
            var json = JsonContent.Create(notes);

            HttpResponseMessage response = await client.PutAsync(
                $"api/Notes", json);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Изменение завершилось с ошибкой!");
            }
            return;
        }

        public async Task DeleteNotes(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/Notes/{id}");
            response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Удаление завершилось с ошибкой!");
            }
            return;
        }

    }
}
