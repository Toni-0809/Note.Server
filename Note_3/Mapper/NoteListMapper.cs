using Note_3.DTOs;
namespace Note_3.Mapper
{
    public static class NoteListMapper 
    { 
    
        public static Note_3.Entities.NoteList ToEntity(this AddNoteListDTO game)
        {
            return new Entities.NoteList()
            {
                Title = game.Title,
            };

        }

        public static Entities.NoteList ToEntity(this UpdateNoteListDTO game, int id)
        {
            return new Entities.NoteList()
            {
                Title = game.Title,
            };
        }

        public static NoteListDTO ToNoteListDTO(this Entities.NoteList game)
        {
            return new NoteListDTO(

              game.Id,
              game.Title
            );
        }
    }
}
