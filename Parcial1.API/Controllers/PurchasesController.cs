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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await dataContext.Purchases.FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpPut]
        public async Task<ActionResult> Put(Purchase purchase)
        {
            dataContext.Purchases.Update(purchase);
            await dataContext.SaveChangesAsync();
            return Ok(purchase);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await dataContext.Purchases.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}