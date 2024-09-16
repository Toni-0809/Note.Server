using Note_3.DTOs;

namespace Note_3.Mapper
{
    public static class NotesMapper
    {
        public static Note_3.Entities.Notes ToEntity(this AddNotesDTO game)
        {
            return new Entities.Notes()
            {
                UserId = game.UserId,
                NoteListId = game.NoteListId,
                Title = game.Title,
                Entry = game.Entry

            };
        }

        public static Entities.Notes ToEntity(this UpdateNotesDTO game, int id)
        {
            return new Entities.Notes()
            {
                UserId = game.UserId,
                Title = game.Title,
                Entry = game.Entry
            };
        }

        public static NotesDTO ToNotesDTO(this Entities.Notes game)
        {
            return new NotesDTO(
                game.Id,
                game.Title,
                game.Entry,
                game.UserId,
                game.NoteListId
                );
        }
    }
}