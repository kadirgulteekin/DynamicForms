using FormService.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public FormsController(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }
    }
}
