namespace TechnicalRadiation.Models.DetailDtos
{
    public class NewsItemDetailDto : HyperMediaModel
    {
         public int Id { get; set; }
        public string Title { get; set; }
        public string ImgSource { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int PublishDate { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}