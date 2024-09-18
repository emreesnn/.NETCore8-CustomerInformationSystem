using mbs.Application.Features.Books.Commands.CreateBook;
using mbs.Application.Features.Books.Commands.DeleteBook;
using mbs.Application.Features.Books.Commands.UpdateBook;
using mbs.Application.Features.Books.Queries.GetAllBooks;
using mbs.Application.Features.Books.Queries.GetBookById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace mbs.Presentation.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator mediator;

        public BookController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var response = await mediator.Send(new GetAllBooksQueryRequest());
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetBookById([FromRoute] GetBookByIdQueryRequest getBookByIdQueryRequest )
        {
            var response = await mediator.Send(getBookByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(UpdateBookCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(DeleteBookCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }


    }
}
