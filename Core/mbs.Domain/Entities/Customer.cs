using mbs.Domain.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Domain.Entities
{
    public class Customer : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Template> Templates { get; set; } = new Collection<Template>();

    }
}
