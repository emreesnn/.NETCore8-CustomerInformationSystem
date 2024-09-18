using AutoMapper;
using mbs.Application.Features.Books.Queries.GetAllBooks;
using mbs.Application.Features.Books.Rules;
using mbs.Application.Interfaces;
using mbs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace mbs.Application.Services.BookServices
{
    public class BookManager : IBookService
    {
        private readonly IRepository<Book> repository;
        private readonly BookRules bookRules;

        public BookManager(IRepository<Book> repository, BookRules bookRules)
        {
            this.repository = repository;
            this.bookRules = bookRules;
        }
        
        public async Task<Book?> AddAsync(Book data)
        {
            await bookRules.BookTitleMustBeUnique(data.Title);
            var createdEntity = await repository.CreateAsync(data);
            return createdEntity;
        }

        public async Task DeleteAsync(Book data, bool permanent = false)
        {
            var entity = await repository.GetAsync(b => b.Id == data.Id);
            if (entity == null)
            {
                throw new NotFoundException("Silinmek istenen kitap bulunamadı!");
            }
            await repository.DeleteAsync(data.Id);
        }
        public async Task<Book?> UpdateAsync(Book data)
        {
            var entity = await repository.GetAsync(b => b.Id == data.Id);
            if (entity == null)
            {
                throw new NotFoundException("Güncellenmek istenen kitap bulunamadı!");
            }

            entity.Title = data.Title;
            entity.Description = data.Description;
            entity.Price = data.Price;
            entity.AuthorId = data.AuthorId;

            var updatedEntity = await repository.UpdateAsync(entity.Id, entity);
            return updatedEntity;
        }

        public async Task<Book?> GetAsync(
            Expression<Func<Book, bool>> predicate = null, 
            Func<IQueryable<Book>, IIncludableQueryable<Book, object>>? include = null, 
            bool withDeleted = false, bool enableTracking = true, 
            CancellationToken cancellationToken = default)
        {

            var book = await repository.GetAsync(predicate, include, enableTracking);
            if (book == null)
            {
                throw new NotFoundException("İstenen kitap bulunamadı!");
            }
            return book;
           
        }

        public async Task<IList<Book>?> GetAllAsync(
            Expression<Func<Book, bool>> predicate = null, 
            Func<IQueryable<Book>, IIncludableQueryable<Book, object>>? include = null, 
            Func<IQueryable<Book>, IOrderedQueryable<Book>>? orderBy = null, 
            bool withDeleted = false, bool enableTracking = true, 
            CancellationToken cancellationToken = default)
        {
            var books = await repository.GetAllAsync(predicate, include, orderBy, enableTracking);
            if (books == null)
            {
                throw new NotFoundException("Kitaplar bulunamadı!");
            }
            return books;  

        }
    }
}
