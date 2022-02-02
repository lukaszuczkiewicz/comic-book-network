﻿using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ComicSocialRepository : IComicSocialRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ComicSocialRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddComicSocial(ComicSocial comicSocial)
        {
            _context.ComicSocial.Add(comicSocial);
        }

        public async Task<ComicSocialDto> GetComicSocialDataAsync(int comicId, int appUserId)
        {
            return await _context.ComicSocial
                .ProjectTo<ComicSocialDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.ComicId == comicId && x.AppUserId == appUserId);
        }

        public async Task<ComicSocial> GetComicSocialAsync(int comicId, int appUserId)
        {
            return await _context.ComicSocial
                .Where(x => x.ComicId == comicId && x.AppUserId == appUserId)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(ComicSocial comicSocial)
        {
            _context.Entry(comicSocial).State = EntityState.Modified;
        }
    }
}
