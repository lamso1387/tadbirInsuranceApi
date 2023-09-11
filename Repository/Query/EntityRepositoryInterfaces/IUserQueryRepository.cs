
using tadbirInsuranceApi.Domain; 

namespace tadbirInsuranceApi.Repository
{
    public interface IUserQueryRepository : IGenericQueryRepository<User>
    { 
        Task<User?> GetByUsername(string username);
        Task<List<string>> GetPermissions(User user);
    }
}
