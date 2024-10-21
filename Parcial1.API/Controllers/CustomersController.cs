using Parcial1.API.Data;
using Parcial1.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Parcial1.API.Controllers
{
    [ApiController]
    [Route("/api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly DataContext dataContext;
        public CustomersController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Customers.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Customer customer)
        {
            dataContext.Customers.Add(customer);
            await dataContext.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await dataContext.Customers.FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpPut]
        public async Task<ActionResult> Put(Customer customer)
        {
            dataContext.Customers.Update(customer);
            await dataContext.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await dataContext.Customers.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}