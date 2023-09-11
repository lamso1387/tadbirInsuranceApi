
using tadbirInsuranceApi.Data;
using tadbirInsuranceApi.Domain; 

namespace tadbirInsuranceApi.Repository
{
    public class InsurancePolicyQueryRepository : GenericQueryRepository<InsurancePolicy>, IInsurancePolicyQueryRepository
    {
        public InsurancePolicyQueryRepository(InsuranceQueryDbContext dbContext) : base(dbContext)
        {

        }  
    }
}
