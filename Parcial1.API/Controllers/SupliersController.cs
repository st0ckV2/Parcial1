using Parcial1.API.Data;
using Parcial1.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Parcial1.API.Controllers
{
    [ApiController]
    [Route("/api/supliers")]
    public class SupliersController : ControllerBase
    {
        private readonly DataContext dataContext;
        public SupliersController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Supliers.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Suplier suplier)
        {
            dataContext.Supliers.Add(suplier);
            await dataContext.SaveChangesAsync();
            return Ok(suplier);
        }
    }
}