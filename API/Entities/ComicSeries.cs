namespace API.Entities
{
    public class ComicSeries
    {
        public int Id { get; set; }
        public string SeriesName { get; set; }
        public string Publisher { get; set; }
        public string Writer { get; set; }
        public string Artist { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }

        public ICollection<Comic> Comics { get; set; }
    }
}
