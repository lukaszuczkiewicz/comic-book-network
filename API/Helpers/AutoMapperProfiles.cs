using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>();
            CreateMap<ComicComment, ComicCommentDto>();
            CreateMap<ComicSocial, ComicSocialDto>();

            CreateMap<ComicSeries, ComicSeriesDto>();
            CreateMap<Comic, ComicDto>();
        }
    }
}
