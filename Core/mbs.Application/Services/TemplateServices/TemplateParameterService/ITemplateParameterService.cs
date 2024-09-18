using mbs.Application.Interfaces;
using mbs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Services.TemplateServices.TemplateParameterService
{
    public interface ITemplateParameterService : IService<TemplateParameter>
    {
        Task<ICollection<TemplateParameter>?> AddRangeAsync(ICollection<TemplateParameter> datas);
    }
}
