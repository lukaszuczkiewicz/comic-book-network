using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ComicCommentRepository : IComicCommentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ComicCommentRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //public async Task<ComicDetailDto> GetComicAsync(int id)
        //{
        //    return await _context.Comic
        //        .Join(_context.ComicSeries, c => c.ComicSeriesId, s => s.Id, (c, s) => new { c, s })
        //        .Where(x => x.c.Id == id)
        //        .Select(x => new ComicDetailDto
        //        {
        //            Id = x.c.Id,
        //            PublishDate = x.c.PublishDate,
        //            IssueNumber = x.c.IssueNumber,
        //            Price = x.c.Price,
        //            PageCount = x.c.PageCount,
        //            Photo = x.c.Photo,
        //            Description = x.c.Description,
        //            ComicSeriesId = x.c.ComicSeriesId,

        //            SeriesName = x.s.SeriesName,
        //            Publisher = x.s.Publisher,
        //            Writer = x.s.Writer,
        //            Artist = x.s.Artist
        //        })
        //        .SingleOrDefaultAsync();
        //}

        public async Task<IEnumerable<ComicCommentDto>> GetComicCommentsAsync(int id)
        {
            return await _context.ComicComment
                .Where(x => x.ComicId == id)
                .Join(_context.Users, c => c.AppUserId, u => u.Id, (c, u) => new { c, u })
                .Select(x => new ComicCommentDto
                {
                    Id = x.c.Id,
                    TextContent = x.c.TextContent,
                    Date = x.c.Date,
                    AppUserId = x.c.AppUserId,

                    UserName = x.u.UserName
                })
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Comic comic)
        {
            _context.Entry(comic).State = EntityState.Modified;
        }
    }
}
