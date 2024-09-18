using mbs.Application.Interfaces;
using mbs.Domain.Entities;
using mbs.Persistance.Context;
using mbs.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Persistance
{
    public static class Registration
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {                  
    
            var mySqlVersion = configuration["DatabaseSettings:MySqlServerVersion"];
            var serverVersion = new MySqlServerVersion(new Version(mySqlVersion));
            services.AddDbContext<AppDbContext>(opt =>
            opt.UseMySql(configuration.GetConnectionString("DefaultConnection"), serverVersion)
            );

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 2;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
                opt.SignIn.RequireConfirmedEmail = false;

            }).AddRoles<Role>()
            .AddEntityFrameworkStores<AppDbContext>();

            
           

        }
    }
}
