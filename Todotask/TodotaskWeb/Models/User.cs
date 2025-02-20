﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TodotaskWeb.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public List<Note>? Notes { get; set; }
    }
}
