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

        public async Task<ComicDto> GetComicAsync(int id)
        {
            return await _context.Comic
                .Where(c => c.Id == id)
                .ProjectTo<ComicDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<ComicCardDto>> GetLatestComicsAsync()
        {
            return await _context.Comic
                .Join(_context.ComicSeries, c => c.ComicSeriesId, s => s.Id, (c, s) => new { c, s })
                .OrderByDescending(joined => joined.c.Id)
                .Take(10)
                .Select(x=> new ComicCardDto
                {
                    Id= x.c.Id,
                    SeriesName = x.s.SeriesName,
                    Publisher = x.s.Publisher,
                    IssueNumber = x.c.IssueNumber,
                    Photo = x.c.Photo
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
