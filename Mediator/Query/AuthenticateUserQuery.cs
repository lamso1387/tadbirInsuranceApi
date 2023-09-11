using tadbirInsuranceApi.Domain;
using tadbirInsuranceApi.Models; 
using tadbirInsuranceApi.Services;
using MediatR;

namespace tadbirInsuranceApi.Mediator
{
    public class AuthenticateUserQuery : IRequest<User>
    {
        public AuthenticateRequest? _requestDTO { get; set; }
        public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserQuery, User>
        {
            private readonly UnitOfService _unitOfService;
            public AuthenticateUserHandler(UnitOfService unitOfService) => _unitOfService = unitOfService;
            public async Task<User> Handle(AuthenticateUserQuery request,
                CancellationToken cancellationToken)
            {
                 User? user=await  _unitOfService._userService
                    .Authenticate(request._requestDTO!.username!,request._requestDTO.password!);
                if(user==null) throw new GlobalException(ErrorCode.Unauthorized); 
                return user!;
            }
        }
    }
}
