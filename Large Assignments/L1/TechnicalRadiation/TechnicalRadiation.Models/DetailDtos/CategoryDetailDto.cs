namespace TechnicalRadiation.Models.DetailDtos
{
    public class CategoryDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int NumberOfNewsItems { get; set; }
        public int ParentCategoryId { get; set; }
        
    }
}