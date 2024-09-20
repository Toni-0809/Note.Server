using Note.Core.Data;
using Note.Core.Entity;

namespace Note.Core.Service
{
    /// <summary>
    /// Класс, осуществляющий работу с фильмами 
    /// </summary>
    public class NoteService
    {
        private NoteDataSource _dataSource;
        private List<NoteEntity> _notes = new List<NoteEntity>();
        public NoteService(NoteDataSource dataSource)
        {
            _dataSource = dataSource;
            _notes = _dataSource.Get();
        }
        /// <summary>
        /// Получить все фильмы
        /// </summary>
        /// <returns></returns>
        public List<NoteEntity> GetAll()
        {
            return _notes;
        }
        /// <summary>
        /// Получить фильм по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор фильма</param>
        /// <returns>null в случае, если фильм не найден</returns>
        public NoteEntity Get(int id)
        {
            foreach (NoteEntity note in _notes)
                if (note.ItemId == id)
                    return note;
            return null;
        }
        /// <summary>
        /// Добавить новый фильм
        /// </summary>
        /// <param name="note"></param>
        public void Create(NoteEntity note)
        {
            _notes.Add(note);
            _dataSource.Write(_notes);
        }
        /// <summary>
        /// Удалить фильм по идентификатору
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            foreach (NoteEntity note in _notes)
                if (note.ItemId == id)
                {
                    _notes.Remove(note);
                    break;
                }
            _dataSource.Write(_notes);
        }
        /// <summary>
        /// Обновить фильм
        /// </summary>
        /// <param name="note"></param>
        public void Update(NoteEntity note)
        {
            for (int i = 0; i < _notes.Count; i++)
                if (note.ItemId == _notes[i].ItemId)
                    _notes[i] = note;
            _dataSource.Write(_notes);
        }

    }
}