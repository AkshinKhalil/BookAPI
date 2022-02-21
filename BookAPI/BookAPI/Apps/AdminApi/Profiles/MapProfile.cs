using AutoMapper;
using BookAPI.Apps.AdminApi.DTOs.AuthorDtos;
using BookAPI.Apps.AdminApi.DTOs.BookDtos;
using BookAPI.Apps.AdminApi.DTOs.GenrDtos;
using BookAPI.Data.Entities;

namespace BookAPI.Apps.AdminApi.Profiles
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Genr, GenrGetDto>();
            CreateMap<Genr, GenrInBookGetDto>();
            CreateMap<Author, AuthorGetDto>();
            CreateMap<Author, AuthorInBookGetDto>();
            CreateMap<Book, BookGetDto>()
                .ForMember(dest => dest.Profit, map => map.MapFrom(src => src.SalePrice - src.CostPrice));
        }
    }
}
