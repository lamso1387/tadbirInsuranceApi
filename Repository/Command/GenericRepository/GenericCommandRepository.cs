
using tadbirInsuranceApi.Data;
using Microsoft.EntityFrameworkCore;

namespace tadbirInsuranceApi.Repository 
{
    public class GenericCommandRepository<T> : IGenericCommandRepository<T> where T : class
    {
        protected readonly InsuranceCommandDbContext _dbCommandContext;
        protected DbSet<T> table_command;
        public GenericCommandRepository(InsuranceCommandDbContext dbCommandContext)
        {
            _dbCommandContext = dbCommandContext;
            table_command = _dbCommandContext.Set<T>();
        } 

        public async Task Add(T entity)
        {
            await table_command.AddAsync(entity);
        } 

    }
}
