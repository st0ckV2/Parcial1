using Parcial1.API.Data;
using Parcial1.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Parcial1.API.Controllers
{
    [ApiController]
    [Route("/api/purchasedetails")]
    public class PurchaseDetailsController : ControllerBase
    {
        private readonly DataContext dataContext;
        public PurchaseDetailsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.PurchaseDetails.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(PurchaseDetail purchaseDetail)
        {
            dataContext.PurchaseDetails.Add(purchaseDetail);
            await dataContext.SaveChangesAsync();
            return Ok(purchaseDetail);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await dataContext.PurchaseDetails.FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpPut]
        public async Task<ActionResult> Put(PurchaseDetail purchaseDetail)
        {
            dataContext.PurchaseDetails.Update(purchaseDetail);
            await dataContext.SaveChangesAsync();
            return Ok(purchaseDetail);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await dataContext.PurchaseDetails.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}