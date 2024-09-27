using Parcial1.API.Data;
using Parcial1.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Parcial1.API.Controllers
{
    [ApiController]
    [Route("/api/salesdetails")]
    public class SalesDetailsController : ControllerBase
    {
        private readonly DataContext dataContext;
        public SalesDetailsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.SalesDetails.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(SalesDetail salesDetail)
        {
            dataContext.SalesDetails.Add(salesDetail);
            await dataContext.SaveChangesAsync();
            return Ok(salesDetail);
        }
    }
}