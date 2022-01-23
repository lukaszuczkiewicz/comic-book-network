namespace API.Entities
{
    public class ComicSocial
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public bool IsInCollection { get; set; }
        public bool IsRead { get; set; }
        public bool IsInWishlist { get; set; }

        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public Comic Comic { get; set; }
        public int ComicId { get; set; }
    }
}
