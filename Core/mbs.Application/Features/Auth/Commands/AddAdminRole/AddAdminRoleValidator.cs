using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Auth.Commands.AddAdminRole
{
    public class AddAdminRoleValidator : AbstractValidator<AddAdminRoleRequest>
    {
        public AddAdminRoleValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty();
        }
    }
}
