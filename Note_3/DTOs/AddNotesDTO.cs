using System.ComponentModel.DataAnnotations;

namespace Note_3.DTOs
{
    public record class AddNotesDTO(
        int id,
        [Required][StringLength(256)] string Title,
        [Required] int UserId,
        [Required] int NoteListId,
        string Entry
    );
}