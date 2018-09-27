using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("/api")]
    public class CategoryController : Controller
    {
        private readonly CategoryServices _categoryService = new CategoryServices();

        [HttpGet]
        [Route("/categories")]
        public IActionResult GetAllCategories()
        {
	        return Ok(_categoryService.GetAllCategories());
        }

        [HttpGet]
        [Route("/categories/{id:int}")]
        public IActionResult GetCategoryById(int id)
        {
	        return Ok(_categoryService.GetCategoryById(id));
        }

                [HttpPost]
        [Route("/categories")]
        public IActionResult CreateCategory([FromBody] CategoryInputModel category)
        {
            if (!ModelState.IsValid) { return StatusCode(412, category); }
            var id = _categoryService.CreateCategory(category);
            return CreatedAtRoute("", new { id }, null);
        }

        [HttpPut]
        [Route("{id:int}", Name = "/categories")]
        public IActionResult UpdateCategoryById(int id, [FromBody] CategoryInputModel category)
        {
            if (!ModelState.IsValid) { return StatusCode(412, category); }
            
            _categoryService.UpdateCategoryById(category, id);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id:int}", Name = "/categories")]
        public IActionResult DeleteCategoryById(int id)
        {
            _categoryService.DeleteCategoryById(id);
            return NoContent();
        }

        [HttpPatch]
        [Route("/categories/{categoryId:int}/newsitem/{newsItemId:int}")]
        public IActionResult LinkNewsToCategory(int categoryId, int newsItemId)
        {
            _categoryService.LinkNewsToCategory(categoryId, newsItemId);
            return NoContent();
        }
    }
}