using Microservices.Archicture.SOA.Products.Service.Data;
using Microservices.Archicture.SOA.Products.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Microservices.Archicture.SOA.Products.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(ProductsDbContext db) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get() =>
            await db.Products.ToListAsync();
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById(int id) =>
            await db.Products.FirstOrDefaultAsync(p => p.Id == id);
    }
}
