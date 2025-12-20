using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class RegisterStudentDto
    {
        [Required]
        public string FullName { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        public string? Phone { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; } = null!;
    }
}
