using FormService.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormService.API.Services
{
    public interface IFormManageService
    {
        Task<IActionResult> CreateForm([FromBody] Form form);
        Task<IActionResult> UpdateForm(Guid id, [FromBody] Form updatedForm);
        Task<IActionResult> AddFormData(Guid id, [FromBody] Dictionary<string, string> fieldValues);
    }
}
