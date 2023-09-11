using tadbirInsuranceApi.Repository;
using tadbirInsuranceApi.Services;

namespace tadbirInsuranceApi.Services
{
    public class UnitOfService 
    {
        private readonly IUnitOfWork _unitOfWork; 
        public InsurancePolicyService _insurancePolicyService { get; private set; }
        public UserService _userService { get; private set; } 

        public UnitOfService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _insurancePolicyService = new InsurancePolicyService(_unitOfWork);
            _userService = new UserService(_unitOfWork); 
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
        }
    }
}
