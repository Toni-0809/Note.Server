using System.ComponentModel.DataAnnotations;

namespace Note_3.DTOs
{
    public record class AddNoteListDTO(
         [Required]
         [StringLength(128)]
         string Title);
}