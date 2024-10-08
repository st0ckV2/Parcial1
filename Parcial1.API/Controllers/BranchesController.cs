﻿using Parcial1.API.Data;
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
    }
}