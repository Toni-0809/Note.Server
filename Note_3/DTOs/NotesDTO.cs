namespace Note_3.DTOs
{
    public record class NotesDTO(

        int Id,
        string Title,
        string Entry,
        int UsersId,
        int NoteListId);

}