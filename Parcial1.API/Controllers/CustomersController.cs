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
    }
}