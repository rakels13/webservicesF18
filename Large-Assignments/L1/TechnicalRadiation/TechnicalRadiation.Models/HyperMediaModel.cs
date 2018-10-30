using System.Dynamic;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace TechnicalRadiation.Models
{
    public class HyperMediaModel
    {
        public HyperMediaModel() 
        { 
            Links = new ExpandoObject(); 
        }
        [JsonProperty(PropertyName = "_links")]
        public ExpandoObject Links { get; set; }
    }
}