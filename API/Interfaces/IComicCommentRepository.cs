using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IComicCommentRepository
    {
        void Update(Comic comic);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<ComicCommentDto>> GetComicCommentsAsync(int id);
        //Task<Comic> GetComicWithComments(int id);
    }
}
