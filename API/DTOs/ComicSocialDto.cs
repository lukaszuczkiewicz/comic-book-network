namespace API.DTOs
{
    public class ComicSocialDto
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public bool IsInCollection { get; set; }
        public bool IsRead { get; set; }
        public bool IsInWishlist { get; set; }
        public double? AverageRating { get; set; }

        public int AppUserId { get; set; }
        public int ComicId { get; set; }
    }
}