
using tadbirInsuranceApi.Domain;
using tadbirInsuranceApi.Models;
using tadbirInsuranceApi.Mediator;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel; 

namespace tadbirInsuranceApi.Controllers
{ 
    public abstract class GenericController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected User user_session => HttpContext.Items[nameof(User)] as User;
        public GenericController(IMediator mediator) => _mediator = mediator;
    }

}