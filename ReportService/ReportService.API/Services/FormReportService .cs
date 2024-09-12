using FormService.Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReportService.API.Services
{
    public class FormReportService : IFormReportService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public FormReportService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Dictionary<string, string>>> GetFormDataReport(Guid id)
        {
            var form = await _applicationDbContext.Forms.FindAsync(id);
            if (form == null) return new List<Dictionary<string,string>>();

            var formData = await _applicationDbContext.FormData
                .Where(d => d.FormId == id)
                .ToListAsync();

            var result = new List<Dictionary<string, string>>();

            foreach (var fd in formData)
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(fd.FieldValues!);
                if (dictionary != null)
                {
                    result.Add(dictionary);
                }
            }

            return result;
        }

        public async Task<List<object>> GetFormReportAsync()
        {
            var formReport = await _applicationDbContext.Forms
                .Select(f => new
                {
                    f.FormName,
                    f.FormDescription,
                    DataCount = _applicationDbContext.FormData.Count(d => d.FormId == f.UUID)
                })
                .ToListAsync();

            return formReport.Cast<object>().ToList();
        }
    }
}
