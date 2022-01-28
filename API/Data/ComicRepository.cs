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

        public async Task<IEnumerable<ComicDto>> GetLatestComicsAsync()
        {
            return await _context.Comic
                .OrderByDescending(c => c.Id)
                .Take(10)
                .ProjectTo<ComicDto>(_mapper.ConfigurationProvider)
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
