using FormService.API.Models;
using FormService.API.Services;
using FormService.Infrastructure.Data;
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
        private readonly IFormManageService _formManageService;
        public FormsController(ApplicationDbContext context, IFormManageService formManageService)
        {
            _applicationDbContext = context;
            _formManageService = formManageService;
        }

       
        [HttpPost]
        public async Task<IActionResult> CreateForm([FromBody] Form form)
        {
            var createdForm = await _formManageService.CreateForm(form);

            return Ok(createdForm);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateForm(Guid id, [FromBody] Form updatedForm)
        {
            var form = await _formManageService.UpdateForm(id, updatedForm);

            return Ok(form);
        }

        [HttpPost("{id}/data")]
        public async Task<IActionResult> AddFormData(Guid id, [FromBody] Dictionary<string, string> fieldValues)
        {
            var formData = await _formManageService.AddFormData(id, fieldValues);
            return Ok(formData);
        }
    }
}
