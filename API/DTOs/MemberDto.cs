namespace API.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        public string Introduction { get; set; }
        public string Country { get; set; }

        public ICollection<ComicSocialDto> ComicSocials { get; set; }
        public ICollection<ComicCommentDto> ComicComments { get; set; }
    }
}
