namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IComicRepository ComicRepository { get; }
        IComicSeriesRepository ComicSeriesRepository { get; }
        IComicSocialRepository ComicSocialRepository { get; }
        IComicCommentRepository ComicCommentRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}
