using tadbirInsuranceApi.Domain; 

namespace tadbirInsuranceApi.Repository 
{
    public interface ICoverageCommandRepository : ICoverageQueryRepository,
        IGenericCommandRepository<Coverage>
    { 
    }
}
