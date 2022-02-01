using API.DTOs;
using API.Entities;
using API.Extensions;
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
        private readonly IUserRepository _userRepository;
        private readonly IComicSocialRepository _comicSocialRepository;
        private readonly IMapper _mapper;

        public ComicController(IComicRepository comicRepository, IUserRepository userRepository, IComicSocialRepository comicSocialRepository,
            IMapper mapper)
        {
            _comicRepository = comicRepository;
            _userRepository = userRepository;
            _comicSocialRepository = comicSocialRepository;
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

        [HttpGet("social/{id}")]
        public async Task<ActionResult<ComicSocialDto>> GetComicDetailSocial(int id)
        {
            var username = User.GetUsername();
            var user = await _userRepository.GetUserByUsernameAsync(username);
            var userId = user.Id;

            var comic = await _comicRepository.GetComicAsync(id);
            if (comic == null) return BadRequest("Comic does not exist");

            return await _comicSocialRepository.GetComicSocialAsync(id, userId);
        }

        [HttpPost("rate")]
        public async Task<ActionResult> RateComic(RateToAddDto rateToAddDto)
        {
            var username = User.GetUsername();
            var user = await _userRepository.GetUserByUsernameAsync(username);
            var userId = user.Id;

            var comic = await _comicRepository.GetComicAsync(rateToAddDto.ComicId);
            if (comic == null) return BadRequest("Comic does not exist");

            //comic social already exists - to do: update existing one
            if (await _comicSocialRepository.GetComicSocialAsync(rateToAddDto.ComicId, userId) != null) return BadRequest("Comic Social already exists");

            //if comic social doesn't exist - create a new one
            var comicSocial = new ComicSocial
            {
                AppUserId = userId,
                ComicId = rateToAddDto.ComicId,
                Rate = rateToAddDto.Rate,
            };

            _comicSocialRepository.AddComicSocial(comicSocial);

            if (await _comicSocialRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to add the rate");
        }

        [HttpGet("rated")]
        public async Task<ActionResult<IEnumerable<ComicCardDto>>> GetRatedComics()
        {
            var username = User.GetUsername();
            var user = await _userRepository.GetUserByUsernameAsync(username);
            var userId = user.Id;

            var ratedComics = await _comicRepository.GetRatedComicsAsync(userId);

            return Ok(ratedComics);
        }
    }
}
