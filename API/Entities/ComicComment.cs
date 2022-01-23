namespace API.Entities
{
    public class ComicComment
    {
        public int Id { get; set; }
        public int TextContent { get; set; }
        public DateTime Date { get; set; }

        public Comic Comic { get; set; }
        public int ComicId { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }
}
