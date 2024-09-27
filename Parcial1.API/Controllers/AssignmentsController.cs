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
    }
}