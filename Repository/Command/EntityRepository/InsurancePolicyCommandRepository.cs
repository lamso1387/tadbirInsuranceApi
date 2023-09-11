using tadbirInsuranceApi.Data;
using tadbirInsuranceApi.Domain; 

namespace tadbirInsuranceApi.Repository 
{
    public class InsurancePolicyCommandRepository : InsurancePolicyQueryRepository, IInsurancePolicyCommandRepository
    {
        IGenericCommandRepository<InsurancePolicy> genericCommandRepo;

        public InsurancePolicyCommandRepository(InsuranceCommandDbContext dbCommandContext,
            InsuranceQueryDbContext dbQueryContext) : base(dbQueryContext)
        {
            genericCommandRepo = new GenericCommandRepository<InsurancePolicy>(dbCommandContext);

        }

        public async Task Add(InsurancePolicy entity)
        {
            await genericCommandRepo.Add(entity);
        }
          
    }
}
