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
        private readonly IUnitOfWork _unitOfWork;

        public ComicController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("latest")]
        public async Task<ActionResult<IEnumerable<ComicCardDto>>> GetLatestComics()
        {
            var userId = User.GetUserId();

            var latestComics = await _unitOfWork.ComicRepository.GetLatestComicsAsync(userId);

            return Ok(latestComics);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComicDetailDto>> GetComicDetail(int id)
        {
            return await _unitOfWork.ComicRepository.GetComicDetailAsync(id);
        }

        [HttpGet("social/{id}")]
        public async Task<ActionResult<ComicSocialDto>> GetComicDetailSocial(int id)
        {
            var userId = User.GetUserId();

            var comic = await _unitOfWork.ComicRepository.GetComicAsync(id);
            if (comic == null) return BadRequest("Comic does not exist");

            var averageRating = await _unitOfWork.ComicSocialRepository.GetAverageRatingAsync(id);

            var comicSocial = await _unitOfWork.ComicSocialRepository.GetComicSocialDataAsync(id, userId);

            if (comicSocial == null)
            {
                comicSocial = new ComicSocialDto();
            }

            comicSocial.AverageRating = averageRating;

            return comicSocial;
        }

        [HttpPost("rate")]
        public async Task<ActionResult> RateComic(RateToAddDto rateToAddDto)
        {
            if (rateToAddDto.Rate > 5) return BadRequest("Rate value cannot be larger than 5");

            var userId = User.GetUserId();
            var comic = await _unitOfWork.ComicRepository.GetComicAsync(rateToAddDto.ComicId);
            if (comic == null) return BadRequest("Comic does not exist");

            var existingComicSocial = await _unitOfWork.ComicSocialRepository.GetComicSocialAsync(rateToAddDto.ComicId, userId);

            if (existingComicSocial == null && rateToAddDto.Rate < 1) //don't create an entry
            {
                return BadRequest("No need to add an empty rate");
            }
            else if (existingComicSocial == null) //comic social doesn't exist - create a new entry
            {
                var comicSocial = new ComicSocial
                {
                    AppUserId = userId,
                    ComicId = rateToAddDto.ComicId,
                    Rate = rateToAddDto.Rate,
                    IsRead = true
                };

                _unitOfWork.ComicSocialRepository.AddComicSocial(comicSocial);
            }
            else //comic social already exists for this user and comic - update it
            {
                existingComicSocial.Rate = rateToAddDto.Rate;

                if (existingComicSocial.Rate > 0) //adding rating means that user read that comic
                {
                    existingComicSocial.IsRead = true;
                }

                _unitOfWork.ComicSocialRepository.Update(existingComicSocial);
            }

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Failed to add the rate");
        }

        [HttpPost("add-to-collection")]
        public async Task<ActionResult> AddToCollection(AddToListDto addToListDto)
        {
            var userId = User.GetUserId();

            var comic = await _unitOfWork.ComicRepository.GetComicAsync(addToListDto.ComicId);
            if (comic == null) return BadRequest("Comic does not exist");

            var existingComicSocial = await _unitOfWork.ComicSocialRepository.GetComicSocialAsync(addToListDto.ComicId, userId);

            if (existingComicSocial != null) //comic social already exists for this user and comic - update it
            {
                existingComicSocial.IsInCollection = !existingComicSocial.IsInCollection;
                existingComicSocial.IsInWishlist = false;

                _unitOfWork.ComicSocialRepository.Update(existingComicSocial);
            }
            else //comic social doesn't exist - create a new one
            {
                var comicSocial = new ComicSocial
                {
                    AppUserId = userId,
                    ComicId = addToListDto.ComicId,
                    IsInCollection = true
                };

                _unitOfWork.ComicSocialRepository.AddComicSocial(comicSocial);
            }

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Failed to add the rate");
        }

        [HttpPost("add-to-read")]
        public async Task<ActionResult> AddToRead(AddToListDto addToListDto)
        {
            var userId = User.GetUserId();

            var comic = await _unitOfWork.ComicRepository.GetComicAsync(addToListDto.ComicId);
            if (comic == null) return BadRequest("Comic does not exist");

            var existingComicSocial = await _unitOfWork.ComicSocialRepository.GetComicSocialAsync(addToListDto.ComicId, userId);

            if (existingComicSocial != null) //comic social already exists for this user and comic - update it
            {
                existingComicSocial.IsRead = !existingComicSocial.IsRead;

                _unitOfWork.ComicSocialRepository.Update(existingComicSocial);
            }
            else //comic social doesn't exist - create a new one
            {
                var comicSocial = new ComicSocial
                {
                    AppUserId = userId,
                    ComicId = addToListDto.ComicId,
                    IsRead = true
                };

                _unitOfWork.ComicSocialRepository.AddComicSocial(comicSocial);
            }

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Failed to add the rate");
        }

        [HttpPost("add-to-wishlist")]
        public async Task<ActionResult> AddToWishlist(AddToListDto addToListDto)
        {
            var userId = User.GetUserId();

            var comic = await _unitOfWork.ComicRepository.GetComicAsync(addToListDto.ComicId);
            if (comic == null) return BadRequest("Comic does not exist");

            var existingComicSocial = await _unitOfWork.ComicSocialRepository.GetComicSocialAsync(addToListDto.ComicId, userId);

            if (existingComicSocial != null) //comic social already exists for this user and comic - update it
            {
                existingComicSocial.IsInWishlist = !existingComicSocial.IsInWishlist;
                existingComicSocial.IsInCollection = false;

                _unitOfWork.ComicSocialRepository.Update(existingComicSocial);
            }
            else //comic social doesn't exist - create a new one
            {
                var comicSocial = new ComicSocial
                {
                    AppUserId = userId,
                    ComicId = addToListDto.ComicId,
                    IsInWishlist = true
                };

                _unitOfWork.ComicSocialRepository.AddComicSocial(comicSocial);
            }

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Failed to add the rate");
        }

        [HttpGet("rated")]
        public async Task<ActionResult<IEnumerable<ComicCardDto>>> GetRatedComics()
        {
            var userId = User.GetUserId();
            var comics = await _unitOfWork.ComicRepository.GetRatedComicsAsync(userId);

            return Ok(comics);
        }

        [HttpGet("read")]
        public async Task<ActionResult<IEnumerable<ComicCardDto>>> GetReadComics()
        {
            var userId = User.GetUserId();
            var comics = await _unitOfWork.ComicRepository.GetReadComicsAsync(userId);

            return Ok(comics);
        }

        [HttpGet("collection")]
        public async Task<ActionResult<IEnumerable<ComicCardDto>>> GetComicsFromCollection()
        {
            var userId = User.GetUserId();
            var comics = await _unitOfWork.ComicRepository.GetComicsFromCollectionAsync(userId);

            return Ok(comics);
        }

        [HttpGet("wishlist")]
        public async Task<ActionResult<IEnumerable<ComicCardDto>>> GetComicsFromWishlist()
        {
            var userId = User.GetUserId();
            var comics = await _unitOfWork.ComicRepository.GetComicsFromWishlistAsync(userId);

            return Ok(comics);
        }

        [HttpGet("from-series/{id}")]
        public async Task<ActionResult<IEnumerable<ComicCardDto>>> GetComicsFromSeries(int id)
        {
            var userId = User.GetUserId();
            var comics = await _unitOfWork.ComicRepository.GetComicsFromSeriesAsync(userId, id);

            return Ok(comics);
        }
    }
}
