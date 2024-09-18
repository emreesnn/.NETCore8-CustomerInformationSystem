using mbs.Application.Features.Auth.Rules;
using mbs.Application.Features.Books.Rules;
using mbs.Application.Features.Templates.Rules;
using mbs.Application.Mapper;
using mbs.Application.Middlewares.Exceptions;
using mbs.Application.Pipelines.Authorization;
using mbs.Application.Pipelines.Validation;
using mbs.Application.Services.AuthServices;
using mbs.Application.Services.BookServices;
using mbs.Application.Services.CryptoServices;
using mbs.Application.Services.CustomerServices;
using mbs.Application.Services.OrderServices;
using mbs.Application.Services.TemplateServices;
using mbs.Application.Services.TemplateServices.TemplateParameterService;
using mbs.Application.Services.TemplateServices.TemplateParameterValueService;
using mbs.Application.Services.TokenServices;
using mbs.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            services.AddScoped<IBookService, BookManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddTransient<ITokenService, TokenManager>();
            services.AddTransient<ICustomerService, CustomerManager>();
            services.AddTransient<IOrderService, OrderManager>();
            services.AddTransient<ITemplateService, TemplateManager>();
            services.AddTransient<ITemplateParameterService, TemplateParameterManager>();
            services.AddTransient<ITemplateParameterValueService, TemplateParameterValueManager>();
            services.AddScoped<TokenManager>();
            services.AddTransient<CryptoServices>();
            services.AddTransient<LinkServices>();


            services.AddScoped(typeof(BaseException<>));
            services.AddScoped<BookRules>();
            services.AddScoped<AuthRules>();
            services.AddScoped<TemplateRules>();
            services.AddScoped<TokenSettings>();
            services.Configure<TokenSettings>(configuration.GetSection("JWT"));
            services.AddTransient<ExceptionMiddleware>();

            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehaviour<,>));


            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
            {
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"])),
                    ValidateLifetime = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    ClockSkew = TimeSpan.Zero
                };
            });
            

        }



    }
}
