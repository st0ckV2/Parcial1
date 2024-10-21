using Parcial1.API.Data;
using Parcial1.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Parcial1.API.Controllers
{
    [ApiController]
    [Route("/api/assignments")]
    public class AssignmentsController : ControllerBase
    {
        private readonly DataContext dataContext;
        public AssignmentsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Assignments.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Assignment assignment)
        {
            dataContext.Assignments.Add(assignment);
            await dataContext.SaveChangesAsync();
            return Ok(assignment);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await dataContext.Assignments.FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpPut]
        public async Task<ActionResult> Put(Assignment assignment)
        {
            dataContext.Assignments.Update(assignment);
            await dataContext.SaveChangesAsync();
            return Ok(assignment);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await dataContext.Assignments.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}