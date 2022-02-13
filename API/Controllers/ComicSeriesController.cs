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
        private readonly IUnitOfWork _unitOfWork;

        public ComicSeriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComicSeriesDto>>> GetComicSeries()
        {
            var comicSeries = await _unitOfWork.ComicSeriesRepository.GetAllComicSeriesAsync();

            return Ok(comicSeries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComicSeriesDto>> GetComicSeriesDetail(int id)
        {
            return await _unitOfWork.ComicSeriesRepository.GetComicSeriesByIdAsync(id);
        }
    }
}
