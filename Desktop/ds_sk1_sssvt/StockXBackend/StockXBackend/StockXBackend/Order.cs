using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;

namespace StockXBackend
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; } = new();
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    }
}
