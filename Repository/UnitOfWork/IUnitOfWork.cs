

namespace tadbirInsuranceApi.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IInsurancePolicyCommandRepository _insurancePolicyRepo { get; }
        ICoverageCommandRepository _coverageRepo { get; }
        IUserCommandRepository _userRepo { get; }
        Task<bool> SaveAsync(); 
        //DbContext Class SaveChanges method
        int Save(); 
    }
}
