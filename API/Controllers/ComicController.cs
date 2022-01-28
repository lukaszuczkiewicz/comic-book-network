﻿using API.DTOs;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<ComicDto>> GetComicDetail(int id)
        {
            return await _comicRepository.GetComicAsync(id);
        }
    }
}