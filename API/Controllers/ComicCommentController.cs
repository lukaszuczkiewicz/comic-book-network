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
        private readonly IUnitOfWork _unitOfWork;

        public ComicCommentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult> AddCommentToComic(ComicCommentToAddDto commentToAdd)
        {
            var userId = User.GetUserId();

            var comic = await _unitOfWork.ComicRepository.GetComicAsync(commentToAdd.ComicId);

            if (comic == null) return BadRequest("Comic does not exist");

            var newComment = new ComicComment
            {
                TextContent = commentToAdd.TextContent,
                Date = DateTime.Now,
                AppUserId = userId,
                ComicId = commentToAdd.ComicId
            };
            _unitOfWork.ComicCommentRepository.AddComicComment(newComment);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Failed to add the comment");
        }

        [HttpGet("{comicId}")]
        public async Task<ActionResult> GetComicComments(int comicId)
        {
            var comments = await _unitOfWork.ComicCommentRepository.GetComicCommentsAsync(comicId);

            return Ok(comments);
        }

        [HttpGet("latest")]
        public async Task<ActionResult> GetLatestComments()
        {
            var comments = await _unitOfWork.ComicCommentRepository.GetLatestCommentsAsync();

            return Ok(comments);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            var userId = User.GetUserId();

            var comment = await _unitOfWork.ComicCommentRepository.GetComicComment(id);

            if (comment == null)
                return BadRequest("Comment does not exist.");

            if (comment.AppUserId != userId)
                return Unauthorized();

            _unitOfWork.ComicCommentRepository.DeleteComicComment(comment);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Problem deleting the comment");
        }
    }
}
