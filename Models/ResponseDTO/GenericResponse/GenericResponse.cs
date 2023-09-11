namespace tadbirInsuranceApi.Models
{
    public class GenericResponse
    {
        public int? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
        public string? ErrorDetail { get; set; }
        public string? ErrorData { get; set; }
    }
}
