using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Domain.Entities
{
    public class LinkData
    {
        public int CustomerId { get; set; }
        public int TemplateId { get; set; }
        public DateTime Expiry { get; set; } = DateTime.UtcNow.AddHours(3);
        public required string Endpoint { get; set; } = "api/Customer/ExecuteTemplateForCustomer";
    }
}
