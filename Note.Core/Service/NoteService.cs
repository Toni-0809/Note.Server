using Note.Core.Data;
using Note.Core.Entity;
using Note_3.DTOs;

namespace Note.Core.Service
{
    /// <summary>
    /// Класс, осуществляющий работу/// </summary>
    public class NoteService
    {
        private NoteRemoteDataSource _dataSource;
        private List<NoteEntity> _notes = new List<NoteEntity>();
        public NoteService(NoteRemoteDataSource dataSource)
        {
            _dataSource = dataSource;
            //_notes = _dataSource.Get();
        }
        /// <summary>
        /// Получить все
        /// </summary>
        /// <returns></returns>
        public async Task<List<NotesDTO>> GetAll()
        {
            return await _dataSource.GetNotesList();
        }
        /// <summary>
        /// Получить по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор </param>
        /// <returns>null в случае, если не найдено</returns>
        public async Task<NotesDTO?> Get(int id)
        {
            foreach (NotesDTO notes in await _dataSource.GetNotesList())
                if (notes.Id == id)
                    return notes;
            return null;
        }
        /// <summary>
        /// Добавить новую
        /// </summary>
        /// <param name="note"></param>
        public async Task Create(NotesDTO notes)
        {
            try
            {
                await _dataSource.PostNotes(new AddNotesDTO(
                    notes.Id,
                    notes.Title,notes.UsersId,
                    notes.NoteListId,notes.Entry
                    ));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Удалить по идентификатору
        /// </summary>
        /// <param name="id"></param>
        public async Task Delete(int id)
        {
            try
            {
                await _dataSource.DeleteNotes(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Обновить 
        /// </summary>
        /// <param name="notes"></param>
        public async Task Update(UpdateNotesDTO notes)
        {
            try
            {
                await _dataSource.PutNotes(new UpdateNotesDTO(
                                notes.Title,
                                notes.UserId,
                                notes.NoteListId,
                                notes.Entry
                                ));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}