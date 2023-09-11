using tadbirInsuranceApi.Data;
using tadbirInsuranceApi.Domain; 

namespace tadbirInsuranceApi.Repository 
{
    public class CoverageCommandRepository : CoverageQueryRepository, ICoverageCommandRepository
    {
        IGenericCommandRepository<Coverage> genericCommandRepo;

        public CoverageCommandRepository(InsuranceCommandDbContext dbCommandContext,
            InsuranceQueryDbContext dbQueryContext) : base(dbQueryContext)
        {
            genericCommandRepo = new GenericCommandRepository<Coverage>(dbCommandContext);

        }

        public async Task Add(Coverage entity)
        {
            await genericCommandRepo.Add(entity);
        }
          
    }
}
