using FormService.API.Models;
using FormService.API.Services;
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
        private readonly IFormManageService _formService;
        public FormsController(ApplicationDbContext context, IFormManageService formService)
        {
            _applicationDbContext = context;
            _formService = formService;
        }

       
        [HttpPost]
        public async Task<IActionResult> CreateForm([FromBody] Form form)
        {
            var createdForm = await _formService.CreateForm(form);
            return Ok(200);       
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateForm(Guid id, [FromBody] Form updatedForm)
        {

            var updateForm = await _formService.UpdateForm(id, updatedForm);
            return Ok(updateForm);
        }

        [HttpPost("{id}/data")]
        public async Task<IActionResult> AddFormData(Guid id, [FromBody] Dictionary<string, string> fieldValues)
        {

            var formData = await _formService.AddFormData(id, fieldValues);
            return Ok(formData);
        }
    }
}
