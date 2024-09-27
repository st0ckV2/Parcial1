using Parcial1.API.Data;
using Parcial1.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Parcial1.API.Controllers
{
    [ApiController]
    [Route("/api/sales")]
    public class SalesController : ControllerBase
    {
        private readonly DataContext dataContext;
        public SalesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Sales.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Sale sale)
        {
            dataContext.Sales.Add(sale);
            await dataContext.SaveChangesAsync();
            return Ok(sale);
        }
    }
}