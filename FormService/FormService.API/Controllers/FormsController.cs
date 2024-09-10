using FormService.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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

        [HttpGet("form-report")]
        public async Task<IActionResult> GetFormReport()
        {
            var formReport = await _applicationDbContext.Forms
                .Select(f => new
                {
                    f.FormName,
                    f.FormDescription,
                    DataCount = _applicationDbContext.FormData.Count(d => d.FormId == f.UUID)
                })
                .ToListAsync();

            return Ok(formReport);
            //
        }
    }
}
