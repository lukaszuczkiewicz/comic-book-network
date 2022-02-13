using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
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
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }
        public async Task<IEnumerable<LatestCommentDto>> GetLatestCommentsAsync()
        {
            var result = from cc in _context.ComicComment
                         join u in _context.Users on cc.AppUserId equals u.Id
                         join c in _context.Comic on cc.ComicId equals c.Id
                         join cs in _context.ComicSeries on c.ComicSeriesId equals cs.Id
                         select new LatestCommentDto
                         {
                             //from ComicComment
                             Id = cc.Id,
                             TextContent = cc.TextContent,
                             Date = cc.Date,
                             AppUserId = cc.AppUserId,
                             ComicId = cc.ComicId,
                             //from AppUser
                             UserName = u.UserName,
                             //from Comic
                             IssueNumber = c.IssueNumber,
                             Photo = c.Photo,
                             ComicSeriesId = c.ComicSeriesId,
                             //from comic series
                             SeriesName = cs.SeriesName
                         };

            return await result
                .OrderByDescending(x => x.Date)
                .Take(5)
                .ToListAsync();
        }

        public void AddComicComment(ComicComment comment)
        {
            _context.ComicComment.Add(comment);
        }

        public void DeleteComicComment(ComicComment comment)
        {
            _context.ComicComment.Remove(comment);
        }

        public async Task<ComicComment> GetComicComment(int id)
        {
            return await _context.ComicComment
                .SingleOrDefaultAsync(x => x.Id == id);
        }
        public void Update(Comic comic)
        {
            _context.Entry(comic).State = EntityState.Modified;
        }
    }
}
