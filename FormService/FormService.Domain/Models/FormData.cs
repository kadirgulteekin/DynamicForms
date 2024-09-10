namespace FormService.API.Models
{
    public class FormData
    {
        public int Id { get; set; }
        public Guid FormId { get; set; }
        public string? FieldValues { get; set; } 
    }
}
