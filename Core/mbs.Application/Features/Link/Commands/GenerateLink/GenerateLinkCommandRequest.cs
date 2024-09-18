using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Link.Commands.GenerateLink
{
    public class GenerateLinkCommandRequest : IRequest<GenerateLinkCommandResponse>
    {
        public int CustomerId { get; set; }
        public int TemplateId { get; set; }
        public DateTime Expiry { get; set; }
    }
}
