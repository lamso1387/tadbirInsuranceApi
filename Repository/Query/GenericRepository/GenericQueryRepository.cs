using tadbirInsuranceApi.Data;
using tadbirInsuranceApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace tadbirInsuranceApi.Repository
{
    public class GenericQueryRepository<T> : IGenericQueryRepository<T> where T : class
    {
        protected readonly InsuranceQueryDbContext _dbQueryContext;
        protected DbSet<T> table_query;
        public GenericQueryRepository(InsuranceQueryDbContext dbQueryContext)
        {
            _dbQueryContext = dbQueryContext;
            table_query =  _dbQueryContext.Set<T>(); 
        } 
        public async Task<T?> Get(long id)
        {
            return await table_query.FindAsync(id);
        }
    }
}
