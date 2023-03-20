using StackOverflowAPI.Entities;
using StackOverflowAPI.Repositories.Pagination;

namespace StackOverflowAPI.Interfaces
{
    public interface questionInterface
    {
        Task<(IEnumerable<Question>, PaginationMetadata)> GetQuestionsAsync(int pageNumber, int pageSize);

        Task<Question> GetQuestionAsync(int id);

        public void AddQuestion(Question question); 

        Task<IEnumerable<Question>> getUserQuestions(int id);

        public void deleteQuestion(Question question);

        Task<bool> saveQuestionAsync();
    }
}
