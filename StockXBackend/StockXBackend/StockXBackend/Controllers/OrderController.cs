using Microsoft.AspNetCore.Mvc;

namespace StockXBackend.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders.Include(o => o.Products).ToListAsync();
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] List<int> productIds)
        {
            var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var products = await _context.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();

            var order = new Order { UserId = userId, Products = products };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Objednávka vytvořena!" });
        }
    }
}