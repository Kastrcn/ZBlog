using System;
using AutoMapper;
using ZBlog.Areas.Admin.Dtos;
using ZBlog.Data.Entity;

namespace ZBlog.Areas.Admin.Profiles
{
    public class LinkProfile : Profile
    {
        public LinkProfile()
        {
            CreateMap<LinkAddDto, Link>().ForMember(dest => dest.CreateTime,
                    opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.UpdateTime,
                    opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<Link, LinkListDto>();
            CreateMap<Link, LinkEditDto>();
            CreateMap<Link, LinkDto>();
            CreateMap<LinkEditDto, Link>().ForMember(dest => dest.UpdateTime,
                opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}