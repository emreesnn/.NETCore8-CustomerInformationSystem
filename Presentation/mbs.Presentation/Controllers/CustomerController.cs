using mbs.Application.Features.Customers.Commands.CreateCustomer;
using mbs.Application.Features.Customers.Commands.DeleteCustomer;
using mbs.Application.Features.Customers.Commands.UpdateCustomer;
using mbs.Application.Features.Customers.Queries.GetAllCustomers;
using mbs.Application.Features.Customers.Queries.GetCustomerById;
using mbs.Application.Features.Customers.Queries.GetTemplateByCustomerId;
using mbs.Application.Features.Link.Commands.RedirectLink;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace mbs.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var response = await mediator.Send(new GetAllCustomersQueryRequest());
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> RedirectLink([FromQuery]RedirectLinkCommandRequest redirectLinkCommandRequest)
        {
            var response = await mediator.Send(redirectLinkCommandRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] GetCustomerByIdQueryRequest getCustomerByIdQueryRequest)
        {
            var response = await mediator.Send(getCustomerByIdQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCustomerByIdWithTemplates([FromRoute] GetCustomerWithTemplatesQueryRequest getCustomerWithTemplatesQueryRequest)
        {
            var response = await mediator.Send(getCustomerWithTemplatesQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommandRequest createCustomerCommandRequest)
        {
            var response = await mediator.Send(createCustomerCommandRequest);
            return Ok(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerCommandRequest updateCustomerCommandRequest)
        {
            var response = await mediator.Send(updateCustomerCommandRequest);
            return Ok(response);
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(DeleteCustomerCommandRequest deleteCustomerCommandRequest)
        {
            await mediator.Send(deleteCustomerCommandRequest);
            return Ok();
        }

        
    }

}
