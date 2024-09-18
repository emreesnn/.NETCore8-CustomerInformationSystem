using mbs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Link.Commands.DecryptLink
{
    public class DecryptLinkCommandResponse
    {
        public LinkData DecryptedLink { get; set; }
    }
}
