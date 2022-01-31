using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ComicCommentToAddDto
    {
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string TextContent { get; set; }
        [Required]
        public int ComicId { get; set; }
    }
}