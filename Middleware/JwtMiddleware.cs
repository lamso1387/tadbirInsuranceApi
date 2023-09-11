using tadbirInsuranceApi.Controllers;
using tadbirInsuranceApi.Domain;
using tadbirInsuranceApi.Models; 
using tadbirInsuranceApi.Services; 

namespace delivtadbirInsuranceApieryApi.Middleware
{
    public class JwtMiddleware
    {
        protected string[] ignore_authenticaton_actions => new string[] { nameof(UserController.Authenticate) };
        protected string[] ignore_access_control_actions => new string[] { };
        protected bool check_user_first_login => false;
        protected readonly RequestDelegate _next;
        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, UnitOfService _unitOfSrvice)
        {
            var action = context.GetRouteData()?.Values["action"]?.ToString();
            if (action == null) throw new GlobalException(ErrorCode.NotFound);
            if (!ignore_authenticaton_actions.Contains(action))
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                if (string.IsNullOrWhiteSpace(token)) throw new GlobalException(ErrorCode.Unauthorized);

                var user = _unitOfSrvice._userService.ValidateJwtToken(token);
                if (user == null) throw new GlobalException( ErrorCode.Unauthorized);

                if (check_user_first_login && (user.change_pass_next_login == null ? false : (bool)user.change_pass_next_login))
                    throw new GlobalException(ErrorCode.PreconditionFailed, MessageText.PasswordMustBeChanged);

                context.Items[nameof(User)] = user;

                if (!user.is_admin)
                {
                    if (!ignore_access_control_actions.Contains(action))
                    { 
                        if (user.permissions == null) throw new GlobalException(ErrorCode.Forbidden);
                        if (!user.permissions.Contains(action)) throw new GlobalException(ErrorCode.Forbidden);
                    }
                }
            }
            await _next(context);
        }
    }
}
