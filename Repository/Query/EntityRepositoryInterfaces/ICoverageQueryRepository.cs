
using tadbirInsuranceApi.Domain;

namespace tadbirInsuranceApi.Repository
{
    public interface ICoverageQueryRepository : IGenericQueryRepository<Coverage>
    {
        Task<List<Coverage>?> GetByIdList(List<long> ids);
    }
}
