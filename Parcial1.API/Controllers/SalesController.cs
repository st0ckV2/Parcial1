using Parcial1.API.Data;
using Parcial1.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Parcial1.API.Controllers
{
    [ApiController]
    [Route("/api/purchases")]
    public class PurchasesController : ControllerBase
    {
        private readonly DataContext dataContext;
        public PurchasesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Purchases.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Purchase purchase)
        {
            dataContext.Purchases.Add(purchase);
            await dataContext.SaveChangesAsync();
            return Ok(purchase);
        }
    }
}