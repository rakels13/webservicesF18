using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("/api")]
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
        public IActionResult GetNewsById(int id)
        {
	        return Ok(_newsService.GetNewsById(id));
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateNewsItem([FromBody] NewsItemInputModel newsItem)
        {
            if (!ModelState.IsValid) { return StatusCode(412, newsItem); }
            var id = _newsService.CreateNewsItem(newsItem);
            return CreatedAtRoute("GetNewsById",new { id }, null);
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
    }
}