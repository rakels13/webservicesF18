using System;
using Microsoft.AspNetCore.Mvc;
using template.Data;
using template.Models;

namespace TinySoldiers.Controllers
{
    public class ModelController : HyperMediaModel
    {   
        //private readonly DataContext _dataContext = new DataContext();

        [HttpGet]
        [Route("")]
        public IActionResult GetAllModels([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            return Ok();
        }
        //ATH þetta kom 
        private IActionResult Ok()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetModelById")]
        public IActionResult GetModelById(int id)
        {
            return Ok(GetModelById(id));
        }

        private IActionResult Ok(IActionResult actionResult)
        {
            throw new NotImplementedException();
        }
    }
}