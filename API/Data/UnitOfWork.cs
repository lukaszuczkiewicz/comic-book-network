using API.Interfaces;
using AutoMapper;

namespace API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly DataContext _context;
        public readonly IMapper _mapper;
        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IUserRepository UserRepository => new UserRepository(_context, _mapper);

        public IComicRepository ComicRepository => new ComicRepository(_context, _mapper);

        public IComicSeriesRepository ComicSeriesRepository => new ComicSeriesRepository(_context, _mapper);

        public IComicSocialRepository ComicSocialRepository => new ComicSocialRepository(_context, _mapper);

        public IComicCommentRepository ComicCommentRepository => new ComicCommentRepository(_context, _mapper);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}
