using Microsoft.EntityFrameworkCore;
using StackOverflowAPI.ApplicationDbContext;
using StackOverflowAPI.Entities;
using StackOverflowAPI.Interfaces;
using StackOverflowAPI.Repositories.Pagination;

namespace StackOverflowAPI.Repositories
{
    public class QuestionsRepository : questionInterface
    {
        private readonly AppDbContext _context;
        public QuestionsRepository(AppDbContext context)
        {
            _context= context;
        }

        public void AddQuestion(Question question)
        {
            _context.questions.Add(question);
        }

        public void deleteQuestion(Question question)
        {
           _context.questions.Remove(question);
        }

        public async Task<Question> GetQuestionAsync(int id)
        {
            return await _context.questions.Where(x => x.Id == id).FirstAsync();     
        }

        public async Task<(IEnumerable<Question> , PaginationMetadata )> GetQuestionsAsync(int pageNumber, int pageSize)
        {
          var collectiontoReturn =await _context.questions.Skip((pageNumber-1)*pageSize).Take(pageSize).ToListAsync();
            var totalItems = await _context.questions.CountAsync();
            var paginationMetadata= new PaginationMetadata(totalItems, pageSize,pageNumber);
            return (collectiontoReturn, paginationMetadata);
        }

        public async Task<IEnumerable<Question>> getUserQuestions(int id)
        {
           return await _context.questions.Where(x=>x.Author == id).ToListAsync();
        }

        public async Task<bool> saveQuestionAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
