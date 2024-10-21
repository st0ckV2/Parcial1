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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await dataContext.Supliers.FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpPut]
        public async Task<ActionResult> Put(Suplier suplier)
        {
            dataContext.Supliers.Update(suplier);
            await dataContext.SaveChangesAsync();
            return Ok(suplier);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await dataContext.Supliers.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}