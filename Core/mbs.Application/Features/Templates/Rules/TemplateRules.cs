using mbs.Application.Interfaces;
using mbs.Domain.Entities;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Templates.Rules
{
    public class TemplateRules(IRepository<Template> repository)
    {
        public async Task TemplateNameMustBeUnique(string templateName)
        {
            var template = await repository.GetAsync(predicate: x => x.Name == templateName);
            if (template != null && template.IsDeleted is false)
            {
                throw new BadRequestException("Template ismi benzersiz olmalıdır!");
            }
        }
    }
}
