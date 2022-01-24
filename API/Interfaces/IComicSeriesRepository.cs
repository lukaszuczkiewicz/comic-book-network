using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IComicSeriesRepository
    {
        void Update(ComicSeries comicSeries);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<ComicSeriesDto>> GetAllComicSeriesAsync();
        Task<ComicSeriesDto> GetComicSeriesByIdAsync(int id);
    }
}
