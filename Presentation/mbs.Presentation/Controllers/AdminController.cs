using mbs.Application.Features.Link.Commands.DecryptLink;
using mbs.Application.Features.Link.Commands.GenerateLink;

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace mbs.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator mediator;

        public AdminController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> GenerateLink(GenerateLinkCommandRequest generateLinkCommandRequest)
        {
            var response = await mediator.Send(generateLinkCommandRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> DecryptLink(DecryptLinkCommandRequest decryptLinkCommandRequest)
        {
            var response = await mediator.Send(decryptLinkCommandRequest);
            return Ok(response);
        }

        
    }
}
