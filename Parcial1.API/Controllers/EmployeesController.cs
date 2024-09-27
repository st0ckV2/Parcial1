using Parcial1.API.Data;
using Parcial1.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Parcial1.API.Controllers
{
    [ApiController]
    [Route("/api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly DataContext dataContext;
        public EmployeesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Employees.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Employee employee)
        {
            dataContext.Employees.Add(employee);
            await dataContext.SaveChangesAsync();
            return Ok(employee);
        }
    }
}