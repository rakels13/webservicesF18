using template.Models;

namespace TinySoldiers.Models
{
    public class ModelDTO : HyperMediaModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public double Price { get; set; }

    }
}