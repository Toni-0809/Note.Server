
using Note.Core.Entity;
using Note.Core.Utility;


namespace Note.Core.Data
{

    /// <summary>
    /// Класс для доступа к данным о фильмах
    /// </summary>
    public class NoteDataSource
    {
        /// <summary>
        /// Относительный путь к файлу, где хранятся данные
        /// </summary>
        private readonly string path = ".\\Note_data.json";

        /// <summary>
        /// Метод чтения данных в формате JSON 
        /// и их десериализация
        /// </summary>
        /// <returns></returns>
        public List<NoteEntity> Get()
        {
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string data = reader.ReadToEnd();
                    var tmp = DataSerializer.Deserialize<List<NoteEntity>>(data) ?? [];
                    NoteEntity._id_counter = tmp.Count > 0 ? tmp.Select(x => x.ItemId).Max() + 1 : 0;
                    return tmp;
                }

            }
            return [];
        }

        /// <summary>
        /// Метод записи данных в формате JSON 
        /// и их десериализация
        /// </summary>
        /// <returns></returns>
        public void Write(List<NoteEntity> data)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {

                writer.WriteLine(DataSerializer.Serialize(data));
            }
        }
    }
}