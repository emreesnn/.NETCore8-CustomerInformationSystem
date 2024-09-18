using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Link.Commands.DecryptLink
{
    public class DecryptLinkCommandRequest : IRequest<DecryptLinkCommandResponse>
    {
        public string EncryptedLink { get; set; }
    }
}
