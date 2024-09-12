using Microsoft.AspNetCore.Mvc;

namespace ReportService.API.Services
{
    public interface IFormReportService
    {
        Task<List<object>> GetFormReportAsync();

        Task<List<Dictionary<string, string>>> GetFormDataReport(Guid id);
    }
}
