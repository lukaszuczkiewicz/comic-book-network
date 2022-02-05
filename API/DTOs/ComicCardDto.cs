namespace API.DTOs
{
    public class ComicCardDto
    {
        public int Id { get; set; }
        public string SeriesName { get; set; }
        public string Publisher { get; set; }
        public int IssueNumber { get; set; }
        public string Photo { get; set; }

        //comic social
        public bool? IsInCollection { get; set; }
        public bool? IsRead { get; set; }
        public bool? IsInWishlist { get; set; }
    }
}
