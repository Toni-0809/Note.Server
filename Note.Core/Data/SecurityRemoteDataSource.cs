using Note.Core.Utility;
using Note_3.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Note.Core

{
    public class SecurityRemoteDataSource
    {
        public static readonly HttpClient client = new HttpClient();

        public SecurityRemoteDataSource()
        {
            client.BaseAddress = new Uri("http://localhost:5010/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }



        public async Task<SecurityResponse> GetNotes(int id)
        {
            SecurityResponse notes = null;

            HttpResponseMessage response = await client.GetAsync($"api/Notes/{id}");
            if (response.IsSuccessStatusCode)
            {
                notes = DataSerializer.Deserialize<SecurityResponse>(
                   await response.Content.ReadAsStringAsync());
            }
            return notes;
        }


        public async Task PostNotes(SecurityResponse SecurityRequest)
        {
            HttpResponseMessage response = await client.PostAsync(
                ("api/Notes"), JsonContent.Create(SecurityRequest));

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Добавление завершилось с ошибкой!");
            }
            return;
        }
    }
}