using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class ComicController : BaseApiController
    {
        private readonly IComicRepository _comicRepository;
        private readonly IMapper _mapper;

        public ComicController(IComicRepository comicRepository,
            IMapper mapper)
        {
            _comicRepository = comicRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComicCardDto>>> GetLatestComics()
        {
            var latestComics = await _comicRepository.GetLatestComicsAsync();

            return Ok(latestComics);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComicDetailDto>> GetComicDetail(int id)
        {
            return await _comicRepository.GetComicDetailAsync(id);
        }
    }
}
