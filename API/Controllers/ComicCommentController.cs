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

        [HttpPost]
        public async Task<ActionResult> AddCommentToComic(ComicCommentToAddDto commentToAdd)
        {
            var username = User.GetUsername();

            var user = await _userRepository.GetUserByUsernameAsync(username);

            var userId = user.Id;


            var comic = await _comicRepository.GetComicAsync(commentToAdd.ComicId);

            if (comic == null) return BadRequest("Comic does not exist");

            var newComment = new ComicComment
            {
                TextContent = commentToAdd.TextContent,
                Date = DateTime.Now,
                AppUserId = userId,
                ComicId = commentToAdd.ComicId
            };
            _commentRepository.AddComicComment(newComment);

            if (await _commentRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to add the comment");
        }

        [HttpGet("{comicId}")]
        public async Task<ActionResult> GetComicComments(int comicId)
        {
            var comments = await _commentRepository.GetComicCommentsAsync(comicId);

            return Ok(comments);
        }

        [HttpGet("latest")]
        public async Task<ActionResult> GetLatestComments()
        {
            var comments = await _commentRepository.GetLatestCommentsAsync();

            return Ok(comments);
        }
    }
}
