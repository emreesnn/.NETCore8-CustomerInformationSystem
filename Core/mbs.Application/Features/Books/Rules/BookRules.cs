using mbs.Application.Interfaces;
using mbs.Domain.Entities;
using FluentValidation;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Features.Books.Rules
{
    public class BookRules(IRepository<Book> repository)
    {
        public async Task BookTitleMustBeUnique(string bookTitle)
        {
            var book = await repository.GetAsync(predicate: x => x.Title == bookTitle);
            if (book != null)
            {
                throw new BadRequestException("Kitap ismi benzersiz olmalıdır!");
            }
        }
    }
}
