
using tadbirInsuranceApi.Data;
using tadbirInsuranceApi.Domain;
using tadbirInsuranceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace tadbirInsuranceApi.Repository
{
    public class UserQueryRepository : GenericQueryRepository<User>, IUserQueryRepository
    {
        public UserQueryRepository(InsuranceQueryDbContext dbContext) : base(dbContext)
        {

        } 

        public async Task<User?> GetByUsername(string username)
        {
            return await table_query.FirstOrDefaultAsync(x => x.username.ToLower().Equals(username.ToLower()));
        }
        public async Task<List<string>> GetPermissions(User user)
        {
            List<string?> all_permissions = new List<string?>();
            user.user_roles = await _dbQueryContext.UserRoles.Where(x => x.user_id == user.id).ToListAsync();

            all_permissions = await _dbQueryContext.Roles
                .Where(x => x.user_roles!.Select(y => y.role_id).Contains(x.id)).Select(y => y.permissions).ToListAsync();
            
            List<string> permissions = new List<string>();

            if (all_permissions.Any())
                all_permissions.ForEach(x => permissions.AddRange(x!.Split(",").ToList()));
            return permissions.Distinct().ToList();
        }

    }
}
