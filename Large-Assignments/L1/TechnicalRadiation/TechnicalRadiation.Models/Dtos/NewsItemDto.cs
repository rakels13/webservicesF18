namespace TechnicalRadiation.Models.Dtos
{
    public class NewsItemDto : HyperMediaModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImgSource { get; set; }
        public string ShortDescription { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}