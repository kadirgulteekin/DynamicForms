namespace FormService.API.Models
{
    public class FormField
    {
        public int Id { get; set; }
        public string? FieldName { get; set; }
        public string? FieldType { get; set; }
        public bool? IsRequired { get; set; }
    }
}
