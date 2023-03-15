using StackOverflowAPI.Entities;

namespace StackOverflowAPI.Interfaces
{
    public interface questionInterface
    {
        Task<IEnumerable<Question>> GetQuestionsAsync();

        Task<Question> GetQuestionAsync(int id);

        public void AddQuestion(Question question); 

        Task<IEnumerable<Question>> getUserQuestions(int id);

        public void deleteQuestion(Question question);

        Task<bool> saveQuestionAsync();
    }
}
