using Manifesto.Services;
using Microsoft.AspNetCore.Mvc;
using Manifesto.WebApi;
using Manifesto.Models;
using Manifesto.Models.InputModels;

namespace Manifesto.WebApi
{
    public class BookController
    {
        private readonly BookService _bookService = new BookService();

        [HttpGet]
        [Route("")]
        public IActionResult GetAllBooks([FromQuery] string category)
        {
            return Ok(_bookService.GetAllBooks(string category));
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetBookById(int id)
        {
            return Ok(_bookService.GetBookById(id));
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateBook([FromBody] BookInputModel book)
        {
            if (!ModelState.IsValid) {return StatusCode(412, book);}
            var id = _bookService.CreateBook(book);
            return CreatedAtRoute("GetBookById", new {id}, null);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateBookByID([FromBody] BookInputModel book, int id)
        {
            if (!ModelState.IsValid) {return StatusCode(412, book);}
            _bookService.UpdateBookById(book, id);
            return NoContent();
        }


        [HttpPut]
        [Route("{id:int}")]
        public IActionResult DeleteBookByID(int id)
        {
            _bookService.DeleteBookById(int id);
            return NoContent();
        }
    }
}