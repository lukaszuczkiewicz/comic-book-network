using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IComicSocialRepository
    {
        void Update(ComicSocial comicsocial);
        Task<bool> SaveAllAsync();
        Task<ComicSocialDto> GetComicSocialDataAsync(int comicId, int appUserId);
        Task<ComicSocial> GetComicSocialAsync(int comicId, int appUserId);
        Task<double?> GetAverageRatingAsync(int comicId);
        void AddComicSocial(ComicSocial comicSocial);
    }
}
