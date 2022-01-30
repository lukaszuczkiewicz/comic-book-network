namespace API.DTOs
{
    public class ComicCommentDto
    {
        //from ComicComment
        public int Id { get; set; }
        public string TextContent { get; set; }
        public DateTime Date { get; set; }

        //from AppUser
        public int AppUserId { get; set; }
        public string UserName { get; set; }
    }
}