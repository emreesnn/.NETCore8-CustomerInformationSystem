using mbs.Application.Interfaces;
using mbs.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Services.CustomerServices
{
    public interface ICustomerService : IService<Customer>
    {
        
    }
}
