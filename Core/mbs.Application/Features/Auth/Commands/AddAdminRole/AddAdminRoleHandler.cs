using mbs.Application.Services.AuthServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Auth.Commands.AddAdminRole
{
    public class AddAdminRoleHandler : IRequestHandler<AddAdminRoleRequest, Unit>
    {
        private readonly IAuthService authManager;

        public AddAdminRoleHandler(IAuthService authManager)
        {
            this.authManager = authManager;
        }
        public async Task<Unit> Handle(AddAdminRoleRequest request, CancellationToken cancellationToken)
        {
            await authManager.AddAdminRoleById(request.UserId);
            return Unit.Value;
        }
    }
}
