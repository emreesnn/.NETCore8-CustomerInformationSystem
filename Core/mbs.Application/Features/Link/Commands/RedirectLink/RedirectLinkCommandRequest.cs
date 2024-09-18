using MediatR;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Link.Commands.RedirectLink
{
    public class RedirectLinkCommandRequest : IRequest<IEnumerable<ExpandoObject>>
    {
        public string EncryptedLink { get; set; }
    }
}
