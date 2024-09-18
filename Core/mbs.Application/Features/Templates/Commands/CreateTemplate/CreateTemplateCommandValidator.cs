using mbs.Application.Features.Templates.Queries.ExecuteTemplate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Templates.Commands.CreateTemplate
{
    public class CreateTemplateCommandValidator : AbstractValidator<CreateTemplateCommandRequest>
    {
        public CreateTemplateCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255)
                .WithName("İsim");

            RuleFor(x => x.Sql)
                .NotEmpty()
                .WithName("Sql");
        }
    }
}
