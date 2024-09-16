using System.ComponentModel.DataAnnotations;

namespace Note_3.DTOs
{
    public record class UpdateNoteListDTO(
     [Required]
    [StringLength(128)]
    string Title);
}