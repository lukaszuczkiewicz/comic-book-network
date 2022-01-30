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
    public class ComicCommentController : BaseApiController
    {
        private readonly IComicCommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IComicRepository _comicRepository;

        private readonly IMapper _mapper;

        public ComicCommentController(IComicCommentRepository commentRepository,
            IMapper mapper, IUserRepository userRepository, IComicRepository comicRepository)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _comicRepository = comicRepository;
            _mapper = mapper;
        }

        [HttpPost("{comicId}")]
        public async Task<ActionResult> AddCommentToComic(int comicId)
        {
            //var userId = User.GetUserId();
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());
            var userId = user.Id;
            //var comic = await _commentRepository.GetComicWithComments(comicId);

            //var commentToAdd = new ComicComment
            //{
            //    TextContent = "abc",
            //    Date = DateTime.Now,
            //    AppUserId = userId
            //};

            //comic.ComicComments.Add(commentToAdd);

            //if (await _commentRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to add comment");
        }

        [HttpGet("{comicId}")]
        public async Task<ActionResult> GetComicComments(int comicId)
        {
            var latestComics = await _commentRepository.GetComicCommentsAsync(comicId);

            return Ok(latestComics);
        }
    }
}
