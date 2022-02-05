using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IComicRepository
    {
        void Update(Comic comic);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<ComicCardDto>> GetLatestComicsAsync(int userId);
        Task<IEnumerable<ComicCardDto>> GetRatedComicsAsync(int userId);
        Task<IEnumerable<ComicCardDto>> GetReadComicsAsync(int userId);
        Task<IEnumerable<ComicCardDto>> GetComicsFromCollectionAsync(int userId);
        Task<IEnumerable<ComicCardDto>> GetComicsFromWishlistAsync(int userId);
        Task<IEnumerable<ComicCardDto>> GetComicsFromSeriesAsync(int userId, int seriesId);        
        Task<ComicDetailDto> GetComicDetailAsync(int id);
        Task<Comic> GetComicAsync(int id);
    }
}
