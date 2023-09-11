namespace tadbirInsuranceApi.Repository
{
    public interface IGenericQueryRepository<T> where T : class
    {
        Task<T?> Get(long id);
    }
}
