using mbs.Application.Interfaces;
using mbs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Services.TemplateServices
{
    public interface ITemplateService : IService<Template>
    {
        Task<Template?> AddAllInOneAsync(Template data);
        Task<IEnumerable<ExpandoObject>> ExecuteTemplate(Template template, ICollection<TemplateParameter> parameters, int customerId);
    }
}
