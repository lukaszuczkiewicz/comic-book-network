using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ComicSeriesRepository : IComicSeriesRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ComicSeriesRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ComicSeriesDto>> GetAllComicSeriesAsync()
        {
            return await _context.ComicSeries
                .ProjectTo<ComicSeriesDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ComicSeriesDto> GetComicSeriesByIdAsync(int id)
        {
            return await _context.ComicSeries
                .Where(x => x.Id == id)
                .OrderBy(x => x.SeriesName)
                .ProjectTo<ComicSeriesDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }
        public async Task<ComicDto> GetComicDetailsAsync(int seriesId, int id)
        {
            return await _context.Comic
                .Where(x => x.Id == id && x.ComicSeriesId == seriesId)
                .ProjectTo<ComicDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(ComicSeries comicSeries)
        {
            _context.Entry(comicSeries).State = EntityState.Modified;
        }
    }
}
