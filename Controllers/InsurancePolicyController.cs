
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
    public class InsurancePolicyController : GenericController
    {
        public InsurancePolicyController(IMediator mediator) : base(mediator) { }

        [HttpPost("add")]
        [DisplayName("افزودن بیمه نامه")]
        public async Task<IActionResult> AddInsurancePolicy(AddInsurancePolicyRequestDTO request)
        {
            var response = new SingleResponse<object>();
            request.user_session_id = user_session.id;
            var insurance_policy = await _mediator.Send(new AddInsurancePolicyCommand { _requestDTO = request });
            return response.ToResponse(insurance_policy, InsurancePolicySelector.selector);
        }
         

    }

}