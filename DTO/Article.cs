namespace DTO.Models
{
    public class Article : BaseClass 
    {
        public string Abstract { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ISBN { get; set; }
        public Author AuthorInfo { get; set; }

    }
}