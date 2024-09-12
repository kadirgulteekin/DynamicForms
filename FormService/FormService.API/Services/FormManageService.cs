using FormService.API.Models;
using FormService.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FormService.API.Services
{
    public class FormManageService : IFormManageService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public FormManageService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IActionResult> AddFormData(Guid id, [FromBody] Dictionary<string, string> fieldValues)
        {
            var formData = new FormData
            {
                FormId = id,
                FieldValues = JsonConvert.SerializeObject(fieldValues)
            };

            _applicationDbContext.FormData.Add(formData);
            await _applicationDbContext.SaveChangesAsync();
            return (IActionResult)formData;
        }

        public async Task<IActionResult> CreateForm([FromBody] Form form)
        {
            form.UUID = Guid.NewGuid();
            _applicationDbContext.Forms.Add(form);
            await _applicationDbContext.SaveChangesAsync();
            return (IActionResult)form;
        }

        public async Task<IActionResult> UpdateForm(Guid id, [FromBody] Form updatedForm)
        {
            var form = await _applicationDbContext.Forms.FindAsync(id);
            if (form == null) return new NoContentResult();

            form.IsActive = updatedForm.IsActive;
            form.FormName = updatedForm.FormName;
            form.FormDescription = updatedForm.FormDescription;
            await _applicationDbContext.SaveChangesAsync();
            return (IActionResult)form;
        }
    }
}
