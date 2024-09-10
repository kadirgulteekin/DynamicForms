
using System.ComponentModel.DataAnnotations;

namespace FormService.API.Models
{
    public class Form
    {
        [Key]
        public Guid UUID { get; set; }
        public string? FormName { get; set; }
        public string? FormDescription { get; set; }
        public bool IsActive { get; set; } = true;
        public List<FormField> Fields { get; set; } = new List<FormField>();
    }
}
