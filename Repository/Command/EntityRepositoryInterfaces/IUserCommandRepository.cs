using tadbirInsuranceApi.Domain; 

namespace tadbirInsuranceApi.Repository
{
    public interface IUserCommandRepository : IUserQueryRepository,
        IGenericCommandRepository<User>
    {
    }
}
