using mbs.Domain.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Domain.Entities
{
    public class Template : EntityBase
    {
        public string Name { get; set; }
        public string Sql { get; set; }
        public ICollection<Customer>? Customers{ get; set; } = new Collection<Customer>();
        public ICollection<TemplateParameter> Parameters { get; set; } = new Collection<TemplateParameter>();
    }
}
