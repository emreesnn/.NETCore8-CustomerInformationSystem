using mbs.Application.Pipelines.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Auth.Commands.AddAdminRole
{
    public class AddAdminRoleRequest : IRequest<Unit>, IAuthentication
    {
        public string UserId { get; set; }
    }
}
