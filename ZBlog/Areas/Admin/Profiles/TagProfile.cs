using System;
using AutoMapper;
using ZBlog.Areas.Admin.Dtos;
using ZBlog.Areas.Admin.ViewModel;
using ZBlog.Data.Entity;

namespace ZBlog.Areas.Admin.Profiles
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
         
            
            CreateMap<TagAddDto, Tag>().ForMember(dest => dest.CreateTime,
                    opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.UpdateTime,
                    opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<Tag, TagListDto>();
            CreateMap<Tag, TagEditDto>();
            CreateMap<Tag, TagDto>();
            CreateMap<TagEditDto, Tag>().ForMember(dest => dest.UpdateTime,
                opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}