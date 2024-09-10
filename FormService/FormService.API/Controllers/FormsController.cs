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
        }

        [HttpGet("{id}/data-report")]
        public async Task<IActionResult> GetFormDataReport(Guid id)
        {
            var form = await _applicationDbContext.Forms.FindAsync(id);
            if (form == null) return NotFound();

            var formData = await _applicationDbContext.FormData
                .Where(d => d.FormId == id)
                .ToListAsync();

            var report = formData.Select(fd => JsonConvert.DeserializeObject<Dictionary<string, string>>(fd.FieldValues!));

            return Ok(report);
        }
    }
}
