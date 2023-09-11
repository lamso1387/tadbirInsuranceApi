using tadbirInsuranceApi.Data;
using tadbirInsuranceApi.Domain;   

namespace tadbirInsuranceApi.Repository 
{
    public class UserCommandRepository : UserQueryRepository, IUserCommandRepository
    {
        IGenericCommandRepository<User> genericCommandRepo;

        public UserCommandRepository(InsuranceCommandDbContext dbCommandContext,
            InsuranceQueryDbContext dbQueryContext) : base(dbQueryContext)
        {
            genericCommandRepo = new GenericCommandRepository<User>(dbCommandContext);

        }

        public async Task Add(User entity)
        {
            await genericCommandRepo.Add(entity);
        }
           
    }
}
