﻿using mbs.Application.Features.Auth.Commands.AddAdminRole;
using mbs.Application.Features.Auth.Commands.Login;
using mbs.Application.Features.Auth.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace mbs.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest loginCommandRequest)
        {
            var response = await mediator.Send(loginCommandRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest registerCommandRequest)
        {
            await mediator.Send(registerCommandRequest);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddAdminRole(AddAdminRoleRequest addAdminRoleRequest)
        {
            await mediator.Send(addAdminRoleRequest);
            return Ok();
        }
    }
}
