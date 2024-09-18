using mbs.Application.Features.Templates.Commands.CreateTemplate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.TemplateParameters.Commands.CreateTemplateParameter
{
    public class CreateTemplateParameterCommandRequest : IRequest<List<CreateTemplateParameterCommandResponse>>
    {
        public ICollection<string> ParameterName { get; set; } = [];
        public int TemplateId { get; set; }
    }
}
