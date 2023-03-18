using AutoMapper;

namespace StackOverflowAPI.Profiles
{
    public class commentProfile:Profile
    {
        public commentProfile()
        {
            CreateMap<Request.Comments.AddComment, Entities.Comment>().ReverseMap();
            CreateMap<Request.Comments.UpdateComment, Entities.Comment>().ReverseMap();
        }
    }
}
