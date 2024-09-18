using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.CustomerTemplateParameterValues.Commands.CreateCustomerTemplateParameterValue
{
    public class CreateCustomerTemplateParameterValueCommandResponse
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int CustomerId { get; set; }
        public int TemplateParameterId { get; set; }
    }
}
