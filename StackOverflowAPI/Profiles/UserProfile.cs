using AutoMapper;

namespace StackOverflowAPI.Profiles
{
    public class UserProfile:Profile
    {

        public UserProfile()
        {
            CreateMap<Request.UserAdd, Entities.User>().ReverseMap();
            CreateMap<Request.UserUpdateRequest, Entities.User>().ReverseMap();
        }
    }
}
