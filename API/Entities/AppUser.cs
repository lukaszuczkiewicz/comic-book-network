namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string Introduction { get; set; }
        public string Country { get; set; }

        public ICollection<ComicSocial> ComicSocials { get; set; }
        public ICollection<ComicComment> ComicComments { get; set; }
    }
}
