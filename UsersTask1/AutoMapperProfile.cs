using AutoMapper;
using UsersTask1.models;
using UserTask1.Module;

namespace UsersTask1
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Users, UserVM>().ReverseMap();
            CreateMap<Posts, PostsVM>().ReverseMap();
        }
    }

}
