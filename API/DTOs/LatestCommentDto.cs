namespace API.DTOs
{
    public class LatestCommentDto
    {
        //from ComicComment
        public int Id { get; set; }
        public string TextContent { get; set; }
        public DateTime Date { get; set; }
        public int AppUserId { get; set; }
        public int ComicId { get; set; }

        //from AppUser
        public string UserName { get; set; }

        //from Comic
        public int IssueNumber { get; set; }
        public string Photo { get; set; }
        public int ComicSeriesId { get; set; }

        //from comic series
        public string SeriesName { get; set; }
    }
}