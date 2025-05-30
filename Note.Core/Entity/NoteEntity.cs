﻿using Newtonsoft.Json;

namespace Note.Core.Entity
{

    /// <summary>
   
    /// >>Здесь представлен так называемый Primary конструктор(Доступен с .NET8) 
    /// с необязательным параметром title<<
    /// </summary>
    /// <param name="id">Уникальный идентификатор </param>
    /// <param name="title">Название</param>
    public class NoteEntity
    {
        public static int _id_counter = 0;
        /// <summary>
        /// Обычный конструктор, до .NET8. В новых версиях доступны оба варианта
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        public NoteEntity(string title = "Some Note")
        {
            ItemId = _id_counter++;
            Title = title;
        }

        [JsonProperty("ItemId")]
        public int ItemId { get; set; }

        public string Title { get; set; }


        public override string ToString()
        {
            return ItemId + "|" + Title;
        }
    }

}