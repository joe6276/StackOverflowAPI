using AutoMapper;

namespace StackOverflowAPI.Profiles
{
    public class answerProfile:Profile
    {

        public answerProfile()
        {
            CreateMap<Request.Answer.AddAnswer, Entities.Answer>().ReverseMap();
        }
    }
}
