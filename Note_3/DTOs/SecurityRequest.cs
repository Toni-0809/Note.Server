﻿using System.ComponentModel.DataAnnotations;

namespace Note_3.DTOs

{
    public record class SecurityRequest
        ([Required] string Login,
        [Required] string Password);

}