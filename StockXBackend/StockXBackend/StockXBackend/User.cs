﻿using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;

namespace StockXBackend
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;
    }
}
