using tadbirInsuranceApi.Domain;
using tadbirInsuranceApi.Models;
using tadbirInsuranceApi.Services;
using MediatR;

namespace tadbirInsuranceApi.Mediator
{
    public class AddInsurancePolicyCommand : IRequest<InsurancePolicy>
    {
        public AddInsurancePolicyRequestDTO? _requestDTO { get; set; }
        public class AddInsurancePolicyHandler : IRequestHandler<AddInsurancePolicyCommand, InsurancePolicy>
        {
            private readonly UnitOfService _unitOfService;
            public AddInsurancePolicyHandler(UnitOfService unitOfService) => _unitOfService = unitOfService;
            public async Task<InsurancePolicy> Handle(AddInsurancePolicyCommand request,
                CancellationToken cancellationToken)
            {
                if (request._requestDTO == null)
                    throw new GlobalException(ErrorCode.InvalidRequest);
                request._requestDTO.CheckValidation();
                var entity = new InsurancePolicy();
                entity.CreateFromDTO(request._requestDTO);
                await _unitOfService._insurancePolicyService.Add(entity);

                return entity;
            }
        }
    }
}
