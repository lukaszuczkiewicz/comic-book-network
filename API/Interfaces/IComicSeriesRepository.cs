using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IComicSeriesRepository
    {
        void Update(ComicSeries comicSeries);
        Task<IEnumerable<ComicSeriesDto>> GetAllComicSeriesAsync();
        Task<ComicSeriesDto> GetComicSeriesByIdAsync(int id);
        Task<ComicDto> GetComicDetailsAsync(int id, int seriesId);
    }
}
