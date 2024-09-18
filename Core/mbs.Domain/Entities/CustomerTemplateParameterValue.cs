using mbs.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Domain.Entities
{
    public class CustomerTemplateParameterValue : EntityBase
    {
        public string Value { get; set; }
        public int TemplateParameterId { get; set; }
        public int CustomerId  { get; set; }
    }
}
