using mbs.Application.Services.CryptoServices;
using mbs.Application.Services.TemplateServices.TemplateParameterService;
using mbs.Application.Services.TemplateServices;
using mbs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Link.Commands.RedirectLink
{
    public class RedirectLinkCommandHandler : IRequestHandler<RedirectLinkCommandRequest, IEnumerable<ExpandoObject>>
    {
        private readonly LinkServices linkServices;
        private readonly ITemplateService templateService;
        private readonly ITemplateParameterService templateParameterService;

        public RedirectLinkCommandHandler(LinkServices linkServices, ITemplateService templateService, ITemplateParameterService templateParameterService)
        {
            this.linkServices = linkServices;
            this.templateService = templateService;
            this.templateParameterService = templateParameterService;
        }

        public async Task<IEnumerable<ExpandoObject>> Handle(RedirectLinkCommandRequest request, CancellationToken cancellationToken)
        {
            LinkData linkData = linkServices.DecryptLink(request.EncryptedLink);
            if (linkData.Expiry < DateTime.UtcNow) { throw new Exception("Link has timed out!"); }
            ICollection<TemplateParameter>? templateParameter = await templateParameterService.GetAllAsync(predicate: x => x.TemplateId == linkData.TemplateId);
            Template? template = await templateService.GetAsync(predicate: x => x.Id == linkData.TemplateId);
            IEnumerable<ExpandoObject> result = await templateService.ExecuteTemplate(template, templateParameter, linkData.CustomerId);
            return result;
        }
    }
}
