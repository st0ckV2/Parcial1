using Parcial1.API.Data;
using Parcial1.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Parcial1.API.Controllers
{
    [ApiController]
    [Route("/api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext dataContext;
        public ProductsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Products.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Product product)
        {
            dataContext.Products.Add(product);
            await dataContext.SaveChangesAsync();
            return Ok(product);
        }
    }
}