using API.Extentions;
using System.Text.Json.Serialization;

namespace API.Entities
{
    public class Comic
    {
        public int Id { get; set; }
        [property: JsonConverter(typeof(DateOnlyConverter))]
        public DateOnly PublishDate { get; set; }
        public int IssueNumber { get; set; }
        public decimal Price { get; set; }
        public int PageCount { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }

        public ComicSeries ComicSeries { get; set; }
        public int ComicSeriesId { get; set; }
        public ICollection<ComicSocial> ComicSocials { get; set; }
        public ICollection<ComicComment> ComicComments { get; set; }
    }
}
