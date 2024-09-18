using mbs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Services.AuthServices
{
    public interface IAuthService
    {
        Task<User> GetUserIfValid(string email, string password);
        Task<Tuple<string, DateTime>> CreateToken(User user);
        Task<string> CreateRefreshToken(User user);
        Task Register(User user, string password, string email);
        Task AddAdminRoleById(string id);
    }
}
