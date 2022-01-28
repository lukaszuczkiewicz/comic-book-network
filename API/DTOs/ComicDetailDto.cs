using API.Extentions;
using System.Text.Json.Serialization;

namespace API.DTOs
{
    public class ComicDetailDto
    {
        //from Comic
        public int Id { get; set; }

        [property: JsonConverter(typeof(DateOnlyConverter))]
        public DateOnly PublishDate { get; set; }
        public int IssueNumber { get; set; }
        public decimal Price { get; set; }
        public int PageCount { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }

        public int ComicSeriesId { get; set; }

        //from ComicSeries
        public string SeriesName { get; set; }
        public string Publisher { get; set; }
        public string Writer { get; set; }
        public string Artist { get; set; }
        //public int StartYear { get; set; }
        //public int EndYear { get; set; }
    }
}
