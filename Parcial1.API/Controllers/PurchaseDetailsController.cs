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
    }
}