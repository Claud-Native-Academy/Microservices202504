using Microservices.Architecture.Monolithic.Data;
using Microservices.Architecture.Monolithic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Architecture.Monolithic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(MonolithDbContext db) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get() =>
            await db.Products.ToListAsync();
    }

}
