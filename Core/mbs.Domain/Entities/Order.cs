using mbs.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Domain.Entities
{
    public class Order : EntityBase
    {
        public string? Title { get; set; }
        public string? Desc { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
