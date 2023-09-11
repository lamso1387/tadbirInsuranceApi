using tadbirInsuranceApi.Domain; 

namespace tadbirInsuranceApi.Repository 
{
    public interface IInsurancePolicyCommandRepository : IInsurancePolicyQueryRepository,
        IGenericCommandRepository<InsurancePolicy>
    { 
    }
}
