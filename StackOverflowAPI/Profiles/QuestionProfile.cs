using AutoMapper;

namespace StackOverflowAPI.Profiles
{
    public class QuestionProfile:Profile
    {
        public QuestionProfile()
        {
            CreateMap<Request.Question.AddQuestion, Entities.Question>().ReverseMap();
        }
    }
}
