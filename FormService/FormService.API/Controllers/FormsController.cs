using FormService.API.Models;
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

       
        [HttpPost]
        public async Task<IActionResult> CreateForm([FromBody] Form form)
        {
            form.UUID = Guid.NewGuid();
            _applicationDbContext.Forms.Add(form);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(form);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateForm(Guid id, [FromBody] Form updatedForm)
        {
            var form = await _applicationDbContext.Forms.FindAsync(id);
            if (form == null) return NotFound();

            form.IsActive = updatedForm.IsActive;
            form.FormName = updatedForm.FormName;
            form.FormDescription = updatedForm.FormDescription;
            await _applicationDbContext.SaveChangesAsync();
            return Ok(form);
        }

        [HttpPost("{id}/data")]
        public async Task<IActionResult> AddFormData(Guid id, [FromBody] Dictionary<string, string> fieldValues)
        {
            var formData = new FormData
            {
                FormId = id,
                FieldValues = JsonConvert.SerializeObject(fieldValues)
            };

            _applicationDbContext.FormData.Add(formData);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(formData);
        }
    }
}
