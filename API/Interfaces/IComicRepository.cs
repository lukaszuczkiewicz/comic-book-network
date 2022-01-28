using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IComicRepository
    {
        void Update(Comic comic);
        Task<bool> SaveAllAsync();
        Task<ComicDto> GetComicAsync(int id);
    }
}
