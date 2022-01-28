using API.Extentions;
using System.Text.Json.Serialization;

namespace API.DTOs
{
    public class ComicDto
    {
        public int Id { get; set; }

        [property: JsonConverter(typeof(DateOnlyConverter))]
        public DateOnly PublishDate { get; set; }
        public int IssueNumber { get; set; }
        public decimal Price { get; set; }
        public int PageCount { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
    }
}
