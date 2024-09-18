using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.TemplateParameters.Commands.CreateTemplateParameter
{
    public class CreateTemplateParameterCommandResponse
    {
        public int Id { get; set; }
        public string ParameterName { get; set; }
        public int TemplateId { get; set; }
    }
}
