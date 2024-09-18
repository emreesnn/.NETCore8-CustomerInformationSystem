using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustommerCommandValidator : AbstractValidator<UpdateCustomerCommandRequest>
    {
        public UpdateCustommerCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithName("İsim");
            
        }
    }
}
