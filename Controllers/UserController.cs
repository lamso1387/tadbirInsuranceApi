
using tadbirInsuranceApi.Domain; 
using tadbirInsuranceApi.Mediator;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using tadbirInsuranceApi.Models;

namespace tadbirInsuranceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : GenericController
    {
        public UserController(IMediator mediator) : base(mediator) { }

        [HttpPost("authenticate")]
        [DisplayName("احراز هویت")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest request)
        {
            var response = new SingleResponse<object>();
            var user = await _mediator.Send(new AuthenticateUserQuery { _requestDTO = request });
            return response.ToResponse(user, AuthenticateUserSelector.selector);
        }
         

    }

}