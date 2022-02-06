using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IComicCommentRepository
    {
        void Update(Comic comic);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<ComicCommentDto>> GetComicCommentsAsync(int id);
        Task<IEnumerable<LatestCommentDto>> GetLatestCommentsAsync();
        void DeleteComicComment(ComicComment comment);
        Task<ComicComment> GetComicComment(int id);
        void AddComicComment(ComicComment comment);
    }
}
