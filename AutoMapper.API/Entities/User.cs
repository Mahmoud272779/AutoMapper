﻿using System.ComponentModel.DataAnnotations;

namespace AutoMapper.API.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public DateTimeOffset DateOfBirth { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
