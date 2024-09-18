using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Templates.Commands.CreateTemplate
{
    public class CreateTemplateCommandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sql { get; set; }
        public string ParameterName { get; set; }
    }
}
