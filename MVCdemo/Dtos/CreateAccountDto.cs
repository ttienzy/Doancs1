using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCdemo.Dtos
{
    public class CreateAccountDto
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; } = default!;
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}