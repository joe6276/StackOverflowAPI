using AutoMapper;

namespace StackOverflowAPI.Profiles
{
    public class votesProfile:Profile
    {
        public votesProfile()
        {
            CreateMap<Request.Vote.AddVote, Entities.Vote>().ReverseMap();
            CreateMap<Request.Vote.UpdateVote, Entities.Vote>().ReverseMap();
        }
    }
}
