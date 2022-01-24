using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class ComicSeriesController : BaseApiController
    {
        private readonly IComicSeriesRepository _comicSeriesRepository;
        private readonly IMapper _mapper;

        public ComicSeriesController(IComicSeriesRepository comicSeriesRepository,
            IMapper mapper)
        {
            _comicSeriesRepository = comicSeriesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComicSeriesDto>>> GetComicSeries()
        {
            var comicSeries = await _comicSeriesRepository.GetAllComicSeriesAsync();

            return Ok(comicSeries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComicSeriesDto>> GetComicSeriesById(int id)
        {
            return await _comicSeriesRepository.GetComicSeriesByIdAsync(id);
        }
    }
}
