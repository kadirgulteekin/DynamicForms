using FormService.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ReportService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("form-report")]
        public async Task<IActionResult> GetFormReport()
        {
            var formReport = await _context.Forms
                .Select(f => new
                {
                    f.FormName,
                    f.FormDescription,
                    DataCount = _context.FormData.Count(d => d.FormId == f.UUID)
                })
                .ToListAsync();

            return Ok(formReport);
        }
    }
}
