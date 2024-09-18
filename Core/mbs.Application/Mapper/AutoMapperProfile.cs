using AutoMapper;
using mbs.Application.DTOs;
using mbs.Application.Features.Auth.Commands.Register;
using mbs.Application.Features.Books.Commands.CreateBook;
using mbs.Application.Features.Books.Commands.DeleteBook;
using mbs.Application.Features.Books.Commands.UpdateBook;
using mbs.Application.Features.Books.Queries.GetAllBooks;
using mbs.Application.Features.Books.Queries.GetBookById;
using mbs.Application.Features.Customers.Commands.CreateCustomer;
using mbs.Application.Features.Customers.Commands.DeleteCustomer;
using mbs.Application.Features.Customers.Commands.UpdateCustomer;
using mbs.Application.Features.Customers.Queries.GetAllCustomers;
using mbs.Application.Features.Customers.Queries.GetCustomerById;
using mbs.Application.Features.Customers.Queries.GetTemplateByCustomerId;
using mbs.Application.Features.CustomerTemplateParameterValues.Commands.CreateCustomerTemplateParameterValue;
using mbs.Application.Features.Link.Commands.GenerateLink;
using mbs.Application.Features.TemplateParameters.Commands.CreateTemplateParameter;
using mbs.Application.Features.Templates.Commands.CreateTemplate;
using mbs.Application.Features.Templates.Commands.DeleteTemplate;
using mbs.Application.Features.Templates.Commands.UpdateTemplate;
using mbs.Application.Features.Templates.Queries.GetAllTemplates;
using mbs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            //RESPONSES

            CreateMap<Book, GetBookByIdQueryResponse>().ReverseMap();
            CreateMap<Book, GetAllBooksQueryResponse>().ReverseMap();
            CreateMap<Book, CreateBookCommandResponse>().ReverseMap();
            CreateMap<Book, UpdateBookCommandResponse>().ReverseMap();

            CreateMap<Customer, GetAllCustomersQueryResponse>().ReverseMap();
            CreateMap<Customer, GetCustomerByIdQueryResponse>().ReverseMap();
            CreateMap<Customer, GetCustomerWithTemplatesQueryResponse>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommandResponse>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommandResponse>().ReverseMap();

            CreateMap<Template, CreateTemplateCommandResponse>().ReverseMap();
            CreateMap<Template, UpdateTemplateCommandResponse>().ReverseMap();
            CreateMap<Template, GetAllTemplatesQueryResponse>().ReverseMap();

            CreateMap<TemplateParameter, CreateTemplateParameterCommandResponse>().ReverseMap();

            CreateMap<CustomerTemplateParameterValue, CreateCustomerTemplateParameterValueCommandResponse>().ReverseMap();

            CreateMap<LinkData, GenerateLinkCommandResponse>().ReverseMap();
            
            //REQUESTS

            CreateMap<Book, CreateBookCommandRequest>().ReverseMap();
            CreateMap<Book, UpdateBookCommandRequest>().ReverseMap();
            CreateMap<Book, DeleteBookCommandRequest>().ReverseMap();
            
            CreateMap<Customer, CreateCustomerCommandRequest>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommandRequest>().ReverseMap();
            CreateMap<Customer, DeleteCustomerCommandRequest>().ReverseMap();
            
            CreateMap<Template, CreateTemplateCommandRequest>().ReverseMap();
            CreateMap<Template, UpdateTemplateCommandRequest>().ReverseMap();
            CreateMap<Template, DeleteTemplateCommandRequest>().ReverseMap();
            
            CreateMap<TemplateParameter, CreateTemplateParameterCommandRequest>().ReverseMap();

            CreateMap<CustomerTemplateParameterValue, CreateCustomerTemplateParameterValueCommandRequest>().ReverseMap();         
            
            CreateMap<User, RegisterCommandRequest>().ReverseMap();
            
            CreateMap<LinkData, GenerateLinkCommandRequest>().ReverseMap();

            //DTO'S
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Template, TemplateDto>().ReverseMap();
            

            
        }
    }
}
