using FormService.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ReportService.API.Services;

namespace ReportService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IFormReportService _reportsService;

        public ReportsController(ApplicationDbContext context, IFormReportService reportsService)
        {
            _context = context;
            _reportsService = reportsService;
        }


        [HttpGet("form-report")]
        public async Task<IActionResult> GetFormReport()
        {

            var formReport = await _reportsService.GetFormReportAsync();
            return Ok(formReport);
        }


        [HttpGet("{id}/data-report")]
        public async Task<IActionResult> GetFormDataReport(Guid id)
        {
            var report  = await _reportsService.GetFormDataReport(id);
            return Ok(report);
        }

    }
}
