using mbs.Application.DTOs;
using mbs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Templates.Commands.CreateTemplate
{
    public class CreateTemplateCommandRequest : IRequest<CreateTemplateCommandResponse>
    {
        public string Name { get; set; }
        public string Sql { get; set; }
    }
}
