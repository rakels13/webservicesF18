using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("/api/authors")]
    public class AuthorController : Controller
    {
        private readonly AuthorServices _authorService = new AuthorServices();

        [HttpGet]
        [Route("")]
        public IActionResult GetAllAuthors()
        {
	        return Ok(_authorService.GetAllAuthors());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetAuthorById(int id)
        {
	        return Ok(_authorService.GetAuthorById(id));
        }

        [HttpGet]
        [Route("{id:int}/newsItems")]
        public IActionResult GetNewsByAuthorId(int id)
        {
	        return Ok(_authorService.GetNewsByAuthorId(id));
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateAuthor([FromBody] AuthorInputModel author)
        {
            if (!ModelState.IsValid) { return StatusCode(412, author); }
            var id = _authorService.CreateAuthor(author);
            return CreatedAtRoute("", new { id }, null);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateAuthorById(int id, [FromBody] AuthorInputModel author)
        {
            if (!ModelState.IsValid) { return StatusCode(412, author); }
            
            _authorService.UpdateAuthorById(author, id);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteAuthorById(int id)
        {
            _authorService.DeleteAuthorById(id);
            return NoContent();
        }

        [HttpPatch]
        [Route("{authorId:int}/newsitem/{newsItemId:int}")]
        public IActionResult LinkNewsToAuthor(int authorId, int newsItemId)
        {
            _authorService.LinkNewsToAuthor(authorId, newsItemId);
            return NoContent();
        }
    }
}