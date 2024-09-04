using Microsoft.AspNetCore.Mvc

using Parcial1.API.Data;

namespace Parcial1.API.Controllers
{
    [ApiController]
    [Route("/api/branches")]
    public class BranchesController:ControllerBase
    {
        private readonly DataContext dataContext;

        public BranchesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}
