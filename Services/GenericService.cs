using tadbirInsuranceApi.Domain;
using tadbirInsuranceApi.Models;
using tadbirInsuranceApi.Repository;

namespace tadbirInsuranceApi.Services
{
    public abstract class GenericService<Tentity> where Tentity : class
    {
        public IUnitOfWork _unitOfWork;

        public GenericService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public abstract Task Add(Tentity entity);

    }


}