using Parcial1.API.Data;
using Parcial1.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Parcial1.API.Controllers
{
    [ApiController]
    [Route("/api/branches")]
    public class BranchesController : ControllerBase
    {
        private readonly DataContext dataContext;
        public BranchesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Branches.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Branch branch)
        {
            dataContext.Branches.Add(branch);
            await dataContext.SaveChangesAsync();
            return Ok(branch);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await dataContext.Branches.FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpPut]
        public async Task<ActionResult> Put(Branch branch)
        {
            dataContext.Branches.Update(branch);
            await dataContext.SaveChangesAsync();
            return Ok(branch);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await dataContext.Branches.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}