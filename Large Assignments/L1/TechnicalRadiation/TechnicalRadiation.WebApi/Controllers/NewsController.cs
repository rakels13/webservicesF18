using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("api/")]
    public class NewsController : Controller
    {
        private readonly NewsServices _newsService = new NewsServices();

        [HttpGet] 
        [Route("")]
        public IActionResult GetAllNews([FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            return Ok(_newsService.GetAllNews(pageSize, pageNumber));
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetNewsById")]
        public IActionResult GetModelById(int id)
        {
	        return Ok(_newsService.GetNewsById(id));
        }


        [HttpGet]
        [Route("categories/")]
        public IActionResult GetAllCategories()
        {
	        return Ok(_newsService.GetAllCategories());
        }

        [HttpGet]
        [Route("{id:int}", Name = "categories")]
        public IActionResult GetCategoryById(int id)
        {
	        return Ok(_newsService.GetCategoryById(id));
        }

        [HttpGet]
        [Route("authors")]
        public IActionResult GetAllAuthors()
        {
	        return Ok(_newsService.GetAllAuthors());
        }

        [HttpGet]
        [Route("{id:int}", Name = "authors")]
        public IActionResult GetAuthorById(int id)
        {
	        return Ok(_newsService.GetAuthorById(id));
        }

        [HttpGet]
        [Route("{id:int}", Name = "authors/{authorid}/newsItems")]
        public IActionResult GetNewsByAuthorId(int id)
        {
	        return Ok(_newsService.GetNewsByAuthorId(id));
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateNewsItem([FromBody] NewsItemInputModel newsItem)
        {
            if (!ModelState.IsValid) { return StatusCode(412, newsItem); }
            var id = _newsService.CreateNewsItem(newsItem);
            return CreatedAtRoute("GetNewsById", new { id }, null);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateNewsById(int id, [FromBody] NewsItemInputModel newsItem)
        {
            if (!ModelState.IsValid) { return StatusCode(412, newsItem); }
            
            _newsService.UpdateNewsById(newsItem, id);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteNewsById(int id)
        {
            _newsService.DeleteNewsById(id);
            return NoContent();
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateCategory([FromBody] CategoryInputModel category)
        {
            if (!ModelState.IsValid) { return StatusCode(412, category); }
            var id = _newsService.CreateCategory(category);
            return CreatedAtRoute("", new { id }, null);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCategoryById(int id, [FromBody] CategoryInputModel category)
        {
            if (!ModelState.IsValid) { return StatusCode(412, category); }
            
            _newsService.UpdateCategoryById(category, id);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCategoryById(int id)
        {
            _newsService.DeleteCategoryById(id);
            return NoContent();
        }

                [HttpPost]
        [Route("")]
        public IActionResult CreateAuthor([FromBody] AuthorInputModel author)
        {
            if (!ModelState.IsValid) { return StatusCode(412, author); }
            var id = _newsService.CreateAuthor(author);
            return CreatedAtRoute("", new { id }, null);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateAuthorById(int id, [FromBody] AuthorInputModel author)
        {
            if (!ModelState.IsValid) { return StatusCode(412, author); }
            
            _newsService.UpdateAuthorById(author, id);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteAuthorById(int id)
        {
            _newsService.DeleteAuthorById(id);
            return NoContent();
        }
    }
}