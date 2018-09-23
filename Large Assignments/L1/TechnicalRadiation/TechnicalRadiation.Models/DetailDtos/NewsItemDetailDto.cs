namespace TechnicalRadiation.Models.DetailDtos
{
    public class NewsItemDetailDto
    {
         public int Id { get; set; }
        public string Title { get; set; }
        public string ImgSource { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        // þetta á örugglega að vera int?
        public int PublishDate { get; set; }
    }
}