using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Templates.Commands.DeleteTemplate
{
    public class DeleteTemplateCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
