namespace tadbirInsuranceApi.Models
{
    public class SingleResponse<TModel> : GenericResponse
    {
        public TModel? Model { get; set; }
    }
}
