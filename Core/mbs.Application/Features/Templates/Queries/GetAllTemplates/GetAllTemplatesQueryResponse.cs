using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Templates.Queries.GetAllTemplates
{
    public class GetAllTemplatesQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sql { get; set; }
    }
}
