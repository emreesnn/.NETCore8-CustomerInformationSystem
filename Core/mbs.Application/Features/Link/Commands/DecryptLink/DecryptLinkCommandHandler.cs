using mbs.Application.Services.CryptoServices;
using mbs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Link.Commands.DecryptLink
{
    public class DecryptLinkCommandHandler : IRequestHandler<DecryptLinkCommandRequest, DecryptLinkCommandResponse>
    {
        private readonly LinkServices linkServices;

        public DecryptLinkCommandHandler(LinkServices linkServices)
        {
            this.linkServices = linkServices;
        }
        public Task<DecryptLinkCommandResponse> Handle(DecryptLinkCommandRequest request, CancellationToken cancellationToken)
        {
            LinkData linkData = linkServices.DecryptLink(request.EncryptedLink);

            return Task.FromResult(new DecryptLinkCommandResponse() { DecryptedLink = linkData});   
        }
    }
}
