using mbs.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Domain.Entities
{
    public class TemplateParameter : EntityBase
    { 
        public string ParameterName { get; set; }
        public int TemplateId { get; set; }
        public Template Template { get; set; }
        public ICollection<CustomerTemplateParameterValue>? CustomerTemplateParameterValue { get; set; }
    }
}
