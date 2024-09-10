using FormService.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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


        [HttpGet("{id}/data-report")]
        public async Task<IActionResult> GetFormDataReport(Guid id)
        {
            var form = await _context.Forms.FindAsync(id);
            if (form == null) return NotFound();

            var formData = await _context.FormData
                .Where(d => d.FormId == id)
                .ToListAsync();

            var report = formData.Select(fd => JsonConvert.DeserializeObject<Dictionary<string, string>>(fd.FieldValues!));

            return Ok(report);
        }
    }
}
