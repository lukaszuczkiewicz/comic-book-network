using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ComicRepository : IComicRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ComicRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Comic> GetComicAsync(int id)
        {
            return await _context.Comic
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<ComicDetailDto> GetComicDetailAsync(int id)
        {
            return await _context.Comic
                .Join(_context.ComicSeries, c => c.ComicSeriesId, s => s.Id, (c, s) => new { c, s })
                .Where(x => x.c.Id == id)
                .Select(x => new ComicDetailDto
                {
                    Id = x.c.Id,
                    PublishDate = x.c.PublishDate,
                    IssueNumber = x.c.IssueNumber,
                    Price = x.c.Price,
                    PageCount = x.c.PageCount,
                    Photo = x.c.Photo,
                    Description = x.c.Description,
                    ComicSeriesId = x.c.ComicSeriesId,

                    SeriesName = x.s.SeriesName,
                    Publisher = x.s.Publisher,
                    Writer = x.s.Writer,
                    Artist = x.s.Artist
                })
                .SingleOrDefaultAsync();
        }
        public async Task<IEnumerable<ComicCardDto>> GetLatestComicsAsync(int userId)
        {
            var comicSocialForThisUser = _context.ComicSocial.Where(cs => cs.AppUserId == userId);

            return await (from c in _context.Comic
                          join cs in _context.ComicSeries on c.ComicSeriesId equals cs.Id
                          join s in comicSocialForThisUser on c.Id equals s.ComicId into comicSoc
                          from s in comicSoc.DefaultIfEmpty()
                          orderby c.Id descending
                          select new ComicCardDto
                          {
                                Id = c.Id,
                                SeriesName = cs.SeriesName,
                                Publisher = cs.Publisher,
                                IssueNumber = c.IssueNumber,
                                Photo = c.Photo,
                                //comic social
                                IsRead = s.IsRead,
                                IsInCollection = s.IsInCollection,
                                IsInWishlist = s.IsInWishlist
                          }).Take(10).ToListAsync();
        }

        public async Task<IEnumerable<ComicCardDto>> GetComicsFromCollectionAsync(int userId)
        {
            return await(from s in _context.ComicSocial
                         join c in _context.Comic on s.ComicId equals c.Id
                         join cs in _context.ComicSeries on c.ComicSeriesId equals cs.Id
                         where s.AppUserId == userId && s.IsInCollection == true
                         select new ComicCardDto
                         {
                             Id = c.Id,
                             SeriesName = cs.SeriesName,
                             Publisher = cs.Publisher,
                             IssueNumber = c.IssueNumber,
                             Photo = c.Photo,
                             //comic social
                             IsRead = s.IsRead,
                             IsInCollection = s.IsInCollection,
                             IsInWishlist = s.IsInWishlist
                         }).ToListAsync();
        }

        public async Task<IEnumerable<ComicCardDto>> GetComicsFromWishlistAsync(int userId)
        {
            return await(from s in _context.ComicSocial
                         join c in _context.Comic on s.ComicId equals c.Id
                         join cs in _context.ComicSeries on c.ComicSeriesId equals cs.Id
                         where s.AppUserId == userId && s.IsInWishlist == true
                         select new ComicCardDto
                         {
                             Id = c.Id,
                             SeriesName = cs.SeriesName,
                             Publisher = cs.Publisher,
                             IssueNumber = c.IssueNumber,
                             Photo = c.Photo,
                             //comic social
                             IsRead = s.IsRead,
                             IsInCollection = s.IsInCollection,
                             IsInWishlist = s.IsInWishlist
                         }).ToListAsync();
        }

        public async Task<IEnumerable<ComicCardDto>> GetRatedComicsAsync(int userId)
        {
            return await (from s in _context.ComicSocial
                         join c in _context.Comic on s.ComicId equals c.Id
                         join cs in _context.ComicSeries on c.ComicSeriesId equals cs.Id
                         where s.AppUserId == userId && s.Rate >= 1 && s.Rate <= 5
                         select new ComicCardDto
                         {
                             Id = c.Id,
                             SeriesName = cs.SeriesName,
                             Publisher = cs.Publisher,
                             IssueNumber = c.IssueNumber,
                             Photo = c.Photo,
                             //comic social
                             IsRead = s.IsRead,
                             IsInCollection = s.IsInCollection,
                             IsInWishlist = s.IsInWishlist
                         }).ToListAsync();
        }

        public async Task<IEnumerable<ComicCardDto>> GetReadComicsAsync(int userId)
        {
            return await (from s in _context.ComicSocial
                         join c in _context.Comic on s.ComicId equals c.Id
                         join cs in _context.ComicSeries on c.ComicSeriesId equals cs.Id
                         where s.AppUserId == userId && s.IsRead == true
                         select new ComicCardDto
                         {
                             Id = c.Id,
                             SeriesName = cs.SeriesName,
                             Publisher = cs.Publisher,
                             IssueNumber = c.IssueNumber,
                             Photo = c.Photo,
                             //comic social
                             IsRead = s.IsRead,
                             IsInCollection = s.IsInCollection,
                             IsInWishlist = s.IsInWishlist
                         }).ToListAsync();
        }

        public async Task<IEnumerable<ComicCardDto>> GetComicsFromSeriesAsync(int userId, int seriesId)
        {
            var comicSocialForThisUser = _context.ComicSocial.Where(cs => cs.AppUserId == userId);

            return await (from c in _context.Comic
                          where c.ComicSeriesId == seriesId
                          join soc in comicSocialForThisUser on c.Id equals soc.ComicId into joined
                          from j in joined.DefaultIfEmpty()
                          join cs in _context.ComicSeries on c.ComicSeriesId equals cs.Id
                          select new ComicCardDto
                          {
                              Id = c.Id,
                              SeriesName = cs.SeriesName,
                              Publisher = cs.Publisher,
                              IssueNumber = c.IssueNumber,
                              Photo = c.Photo,
                              //comic social
                              IsRead = j.IsRead,
                              IsInCollection = j.IsInCollection,
                              IsInWishlist = j.IsInWishlist
                          }).ToListAsync();
        }

        public void Update(Comic comic)
        {
            _context.Entry(comic).State = EntityState.Modified;
        }
    }
}
