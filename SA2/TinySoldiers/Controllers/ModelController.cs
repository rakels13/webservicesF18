using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using template.Data;
using template.Extensions;
using template.Models;
using TinySoldiers.Models;

namespace TinySoldiers.Controllers
{
    [Route("api/tinysoldiers")]
    public class ModelController : Controller
    {   
        [HttpGet]
        [Route("")]
        public IActionResult GetAllModels([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            /*Setting to defult if not */
            if(pageNumber == 0) { pageNumber = 1; }
            /*Setting to default if not */
            if(pageSize == 0) { pageSize = 10; }
            /*Accessing the language header and retrieving the value */
            string language = Request.Headers["Accept-language"];
            /*Setting the language to default if not de-DE */
            if (language != "de-DE") { language = "en-US";}

            return Ok(GetAllModelsToEnvelope(pageNumber, pageSize, language));
        }

        public Envelope<ModelDTO> GetAllModelsToEnvelope(int pageNumber, int pageSize, string language)
        {
            /*Total count of models in DataContext */
            decimal modelCount = DataContext.Models.Count();
            /*Calculating maximum pages */
            int maxPages = (int)(Math.Ceiling(modelCount/pageSize));
            /*Calculating how many models are in the beginning of the list before the ones we want */
            int pagesToSkip = (pageNumber-1)*pageSize;

            /*Constructing the ModelDTO list of models */
            IEnumerable<ModelDTO> model =  DataContext.Models.ToLightWeight(language);

            /*Selecting the models to put in the envelope */
            var items = model.Skip(pagesToSkip).Take(pageSize).ToList();

            /*Adding _links reference to each model */
            foreach (var mod in items){
                mod.Links.AddReference("self",string.Format("http://localhost:5000/api/tinysoldiers/{0}", mod.Id));
            }

            /*Constructing the envelope */
            var envelope = new Envelope<ModelDTO>() 
            {
                Items = items,
                PageSize = pageSize,
                PageNumber = pageNumber,
                MaxPages = maxPages
            };
            return envelope;
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetModelById")]
        public IActionResult GetModelById(int id)
        {
            string language = Request.Headers["Accept-language"];
            /*Setting the language to default if not de-DE */
            if (language != "de-DE") { language = "en-US";}
            /*Finding the model by ID - returns null if not found */
            ModelDetailsDTO mod = DataContext.Models.ToDetails(language).FirstOrDefault(m => m.Id == id);
            /*Adding _links reference to the model */
            mod.Links.AddReference("self", string.Format("http://localhost:5000/api/tinysoldiers/{0}", id));
            
            return Ok(mod);
        }
    }
}