using mbs.Application.Services.AuthServices;
using mbs.Application.Services.TokenServices;
using mbs.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly IAuthService authService;

        public LoginCommandHandler(IAuthService authService, TokenManager tokenManager)
        {
            this.authService = authService;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await authService.GetUserIfValid(request.Email, request.Password);
            (string token, DateTime expiration) = await authService.CreateToken(user);
            var refreshToken = await authService.CreateRefreshToken(user);

            return new()
            {
                Token = token,
                Expiration = expiration,
                RefreshToken = refreshToken,
            };
        }
    }
}
