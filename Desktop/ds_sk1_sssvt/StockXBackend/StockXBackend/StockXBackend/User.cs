using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using System.Security.Claims;

namespace StockXBackend
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public ClaimsIdentity? UserName { get; internal set; }
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;

        public static implicit operator User(User v)
        {
            throw new NotImplementedException();
        }
    }
}
