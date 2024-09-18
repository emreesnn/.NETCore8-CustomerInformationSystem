using AutoMapper;
using mbs.Application.Services.CryptoServices;
using mbs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Link.Commands.GenerateLink
{
    public class GenerateLinkCommandHandler : IRequestHandler<GenerateLinkCommandRequest, GenerateLinkCommandResponse>
    {
        private readonly LinkServices linkServices;
        private readonly IMapper mapper;

        public GenerateLinkCommandHandler(LinkServices linkServices, IMapper mapper)
        {
            this.linkServices = linkServices;
            this.mapper = mapper;
        }
        public Task<GenerateLinkCommandResponse> Handle(GenerateLinkCommandRequest request, CancellationToken cancellationToken)
        {
            LinkData linkData = mapper.Map<LinkData>(request);
            string generatedLink = linkServices.GenerateLink(linkData);
            GenerateLinkCommandResponse response = new GenerateLinkCommandResponse() { GeneratedLink = generatedLink};
            return Task.FromResult(response);
        }
    }
}
