using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using ZBlog.Areas.Admin.Dtos;
using ZBlog.Config;
using ZBlog.Data.Entity;
using static ZBlog.Config.PostType;

namespace ZBlog.Areas.Admin.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<PostAddDto, Post>().ForMember(dest => dest.CreateTime,
                    opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.UpdateTime,
                    opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => (int) dest.Status,
                    opt => opt.MapFrom(src => ((int) src.Status)))
                ;
            // CreateMap<PostAddDto, List<Tag>>().ForMember(dest => dest.CreateTime,
            //         opt => opt.MapFrom(src => DateTime.Now))
            //     .ForMember(dest => dest.UpdateTime,
            //         opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<Post, PostListDto>();
            CreateMap<Post, PostEditDto>().ForMember(dest => dest.TagIds,
                opt => opt.MapFrom(src => src.PostTags.Select(item => item.TagId)));
            CreateMap<Post, PostDto>();
            CreateMap<PostEditDto, Post>().ForMember(dest => dest.UpdateTime,
                opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}