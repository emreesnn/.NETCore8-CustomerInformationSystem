using AutoMapper;
using mbs.Application.Features.Auth.Commands.Register;
using mbs.Application.Features.Auth.Rules;
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

namespace mbs.Application.Services.AuthServices
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly ITokenService tokenService;
        private readonly AuthRules authRules;
        private readonly IConfiguration configuration;

        public AuthManager(UserManager<User> userManager, RoleManager<Role> roleManager, ITokenService tokenService, AuthRules authRules, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.tokenService = tokenService;
            this.authRules = authRules;
            this.configuration = configuration;
        }
        public async Task<User> GetUserIfValid(string email, string password)
        {
            User user = await userManager.FindByEmailAsync(email);
            bool checkPassword = await userManager.CheckPasswordAsync(user, password);
            await authRules.EmailOrPasswordMustBeValid(user, checkPassword);
            return user;
        }

        public async Task<Tuple<string, DateTime>> CreateToken(User user)
        {
            IList<string> roles = await userManager.GetRolesAsync(user);
            JwtSecurityToken token = await tokenService.CreateToken(user, roles);
            string _token = new JwtSecurityTokenHandler().WriteToken(token);
            await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);
            return Tuple.Create(_token, token.ValidTo);
        }
        public async Task<string> CreateRefreshToken(User user)
        {
            string refreshToken = tokenService.GenerateRefreshToken();
            _ = int.TryParse(configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);
            await userManager.UpdateAsync(user);
            return refreshToken;
        }

        public async Task Register(User user, string password, string email)
        {
            await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(email));

            user.UserName = email;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                if (!await roleManager.RoleExistsAsync("user"))
                {
                    await roleManager.CreateAsync(new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = "user",
                        NormalizedName = "USER",
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                    });   
                }
                await userManager.AddToRoleAsync(user, "user");
            }
        }

        public async Task AddAdminRoleById(string id)
        {
            User? user = await userManager.FindByIdAsync(id);
            await authRules.CannotFindUser(user);
            if (!await roleManager.RoleExistsAsync("admin"))
            {
                await roleManager.CreateAsync(new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                });
            }
            await userManager.AddToRoleAsync(user, "admin");
        }
    }
}
