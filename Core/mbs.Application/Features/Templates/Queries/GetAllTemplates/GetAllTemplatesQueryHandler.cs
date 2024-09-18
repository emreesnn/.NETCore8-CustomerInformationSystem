using AutoMapper;
using mbs.Application.Services.TemplateServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Templates.Queries.GetAllTemplates
{
    public class GetAllTemplatesQueryHandler : IRequestHandler<GetAllTemplatesQueryRequest, IList<GetAllTemplatesQueryResponse>>
    {
        private readonly IMapper mapper;
        private readonly ITemplateService templateService;

        public GetAllTemplatesQueryHandler(IMapper mapper, ITemplateService templateService)
        {
            this.mapper = mapper;
            this.templateService = templateService;
        }
        public async Task<IList<GetAllTemplatesQueryResponse>> Handle(GetAllTemplatesQueryRequest request, CancellationToken cancellationToken)
        {
            var templates = await templateService.GetAllAsync();
            var result = mapper.Map<IList<GetAllTemplatesQueryResponse>>(templates);
            return result;
        }
    }
}
