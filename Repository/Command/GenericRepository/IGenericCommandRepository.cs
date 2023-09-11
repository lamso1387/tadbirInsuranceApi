namespace tadbirInsuranceApi.Repository
{
    public interface IGenericCommandRepository<T> where T : class
    {      
        Task Add(T entity); 
    }
}
