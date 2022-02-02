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
            var userId = await GetUserId();

            var comic = await _comicRepository.GetComicAsync(id);
            if (comic == null) return BadRequest("Comic does not exist");

            return await _comicSocialRepository.GetComicSocialDataAsync(id, userId);
        }

        [HttpPost("rate")]
        public async Task<ActionResult> RateComic(RateToAddDto rateToAddDto)
        {
            var userId = await GetUserId();

            var comic = await _comicRepository.GetComicAsync(rateToAddDto.ComicId);
            if (comic == null) return BadRequest("Comic does not exist");
            
            var existingComicSocial = await _comicSocialRepository.GetComicSocialAsync(rateToAddDto.ComicId, userId);

            if (existingComicSocial != null) //comic social already exists for this user and comic - update it
            {
                existingComicSocial.Rate = rateToAddDto.Rate;
                //adding rating means that user read that comic
                if (existingComicSocial.Rate > 0) existingComicSocial.IsRead = true;

                _comicSocialRepository.Update(existingComicSocial);
            }
            else //comic social doesn't exist - create a new one
            {
                var comicSocial = new ComicSocial
                {
                    AppUserId = userId,
                    ComicId = rateToAddDto.ComicId,
                    Rate = rateToAddDto.Rate,
                    IsRead = (rateToAddDto.Rate > 0)
                };

                _comicSocialRepository.AddComicSocial(comicSocial);
            }

            if (await _comicSocialRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to add the rate");
        }

        [HttpPost("add-to-collection")]
        public async Task<ActionResult> AddToCollection(AddToListDto addToListDto)
        {
            var userId = await GetUserId();

            var comic = await _comicRepository.GetComicAsync(addToListDto.ComicId);
            if (comic == null) return BadRequest("Comic does not exist");

            var existingComicSocial = await _comicSocialRepository.GetComicSocialAsync(addToListDto.ComicId, userId);

            if (existingComicSocial != null) //comic social already exists for this user and comic - update it
            {
                existingComicSocial.IsInCollection = !existingComicSocial.IsInCollection;

                _comicSocialRepository.Update(existingComicSocial);
            }
            else //comic social doesn't exist - create a new one
            {
                var comicSocial = new ComicSocial
                {
                    AppUserId = userId,
                    ComicId = addToListDto.ComicId,
                    IsInCollection = true
                };

                _comicSocialRepository.AddComicSocial(comicSocial);
            }

            if (await _comicSocialRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to add the rate");
        }

        [HttpPost("add-to-read")]
        public async Task<ActionResult> AddToRead(AddToListDto addToListDto)
        {
            var userId = await GetUserId();

            var comic = await _comicRepository.GetComicAsync(addToListDto.ComicId);
            if (comic == null) return BadRequest("Comic does not exist");

            var existingComicSocial = await _comicSocialRepository.GetComicSocialAsync(addToListDto.ComicId, userId);

            if (existingComicSocial != null) //comic social already exists for this user and comic - update it
            {
                existingComicSocial.IsRead = !existingComicSocial.IsRead;

                _comicSocialRepository.Update(existingComicSocial);
            }
            else //comic social doesn't exist - create a new one
            {
                var comicSocial = new ComicSocial
                {
                    AppUserId = userId,
                    ComicId = addToListDto.ComicId,
                    IsRead = true
                };

                _comicSocialRepository.AddComicSocial(comicSocial);
            }

            if (await _comicSocialRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to add the rate");
        }

        [HttpPost("add-to-wishlist")]
        public async Task<ActionResult> AddToWishlist(AddToListDto addToListDto)
        {
            var userId = await GetUserId();

            var comic = await _comicRepository.GetComicAsync(addToListDto.ComicId);
            if (comic == null) return BadRequest("Comic does not exist");

            var existingComicSocial = await _comicSocialRepository.GetComicSocialAsync(addToListDto.ComicId, userId);

            if (existingComicSocial != null) //comic social already exists for this user and comic - update it
            {
                existingComicSocial.IsInWishlist = !existingComicSocial.IsInWishlist;

                _comicSocialRepository.Update(existingComicSocial);
            }
            else //comic social doesn't exist - create a new one
            {
                var comicSocial = new ComicSocial
                {
                    AppUserId = userId,
                    ComicId = addToListDto.ComicId,
                    IsInWishlist = true
                };

                _comicSocialRepository.AddComicSocial(comicSocial);
            }

            if (await _comicSocialRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to add the rate");
        }

        [HttpGet("rated")]
        public async Task<ActionResult<IEnumerable<ComicCardDto>>> GetRatedComics()
        {
            var userId = await GetUserId();
            var comics = await _comicRepository.GetRatedComicsAsync(userId);

            return Ok(comics);
        }

        [HttpGet("read")]
        public async Task<ActionResult<IEnumerable<ComicCardDto>>> GetReadComics()
        {
            var userId = await GetUserId();
            var comics = await _comicRepository.GetReadComicsAsync(userId);

            return Ok(comics);
        }

        [HttpGet("collection")]
        public async Task<ActionResult<IEnumerable<ComicCardDto>>> GetComicsFromCollection()
        {
            var userId = await GetUserId();
            var comics = await _comicRepository.GetComicsFromCollectionAsync(userId);

            return Ok(comics);
        }

        [HttpGet("wishlist")]
        public async Task<ActionResult<IEnumerable<ComicCardDto>>> GetComicsFromWishlist()
        {
            var userId = await GetUserId();
            var comics = await _comicRepository.GetComicsFromWishlistAsync(userId);

            return Ok(comics);
        }

        private async Task<int> GetUserId()
        {
            var username = User.GetUsername();
            var user = await _userRepository.GetUserByUsernameAsync(username);
            return user.Id;
        }
    }
}
