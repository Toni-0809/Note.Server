using System.ComponentModel.DataAnnotations;

namespace Note_3.DTOs
{
    public record class AddUserDTO(
    [Required]
    [StringLength(128)]
    string Name
    );
}
