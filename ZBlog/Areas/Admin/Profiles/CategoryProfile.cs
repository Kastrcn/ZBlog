using System;
using AutoMapper;
using ZBlog.Areas.Admin.Dtos;
using ZBlog.Areas.Admin.Params;
using ZBlog.Data.Entity;

namespace ZBlog.Areas.Admin.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>()
                .ForMember(dest => dest.CreateTime,
                    opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.UpdateTime,
                    opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<Category, CategoryListDto>();
            CreateMap<Category, CategoryEditDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryEditDto, Category>().ForMember(dest => dest.UpdateTime,
                opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}