using mbs.Application.Features.Customers.Commands.AddTemplateToCustomer;
using mbs.Application.Features.CustomerTemplateParameterValues.Commands.CreateCustomerTemplateParameterValue;
using mbs.Application.Features.TemplateParameters.Commands.CreateTemplateParameter;
using mbs.Application.Features.Templates.Commands.CreateTemplate;
using mbs.Application.Features.Templates.Commands.DeleteTemplate;
using mbs.Application.Features.Templates.Commands.UpdateTemplate;
using mbs.Application.Features.Templates.Queries.ExecuteTemplate;
using mbs.Application.Features.Templates.Queries.GetAllTemplates;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace mbs.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly IMediator mediator;

        public TemplateController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ExecuteTemplate(ExecuteTemplateQueryRequest executeTemplateQueryRequest)
        {
            var response = await mediator.Send(executeTemplateQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTemplate(CreateTemplateCommandRequest createTemplateCommandRequest)
        {
            var response = await mediator.Send(createTemplateCommandRequest);
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTemplateParameter(CreateTemplateParameterCommandRequest createTemplateParameterCommandRequest)
        {
            var response = await mediator.Send(createTemplateParameterCommandRequest);
            return StatusCode(StatusCodes.Status201Created, response);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateTemplateParameterValue(CreateCustomerTemplateParameterValueCommandRequest createCustomerTemplateParameterValueCommandRequest)
        {
            var response = await mediator.Send(createCustomerTemplateParameterValueCommandRequest);
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPost]
        public async Task<IActionResult> AddTemplateToCustomer(AddTemplateToCustomerCommandRequest addTemplateToCustomerCommandRequest)
        {
            var response = await mediator.Send(addTemplateToCustomerCommandRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTemplates()
        {
            var response = await mediator.Send(new GetAllTemplatesQueryRequest());
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTemplate(UpdateTemplateCommandRequest updateTemplateCommandRequest)
        {
            var response = await mediator.Send(updateTemplateCommandRequest);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTemplate(DeleteTemplateCommandRequest deleteTemplateCommandRequest)
        {
            await mediator.Send(deleteTemplateCommandRequest);
            return Ok();
        }
        
    }
}
