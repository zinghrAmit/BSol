﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSol.API.Models.Auth
{
    [Table("UserTwo")]
    public class UserTwo : IdentityUser
    {
        public string Proffession { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string WorkExperience { get; set; } = string.Empty;
        public double CTC { get; set; }
        public string UserType { get; set; } = string.Empty;
    }
}
