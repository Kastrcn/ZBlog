using AutoMapper;
using ZBlog.Areas.Admin.ViewModel;
using ZBlog.Data.Entity;

namespace ZBlog.Areas.Admin.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentEditViewModel>();
            CreateMap<CommentEditViewModel, Comment>();
        }
    }
}