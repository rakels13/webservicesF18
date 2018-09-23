using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Services;

namespace TechnicalRadiation.WebApi.Controllers
{
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
        [Route("")]
        public IActionResult GetAllCategories()
        {
	        return Ok(_newsService.GetAllCategories());
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetCategoryById")]
        public IActionResult GetCategoryById(int id)
        {
	        return Ok(_newsService.GetCategoryById(id));
        }

    }
}