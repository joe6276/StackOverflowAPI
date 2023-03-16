using Microsoft.EntityFrameworkCore;
using StackOverflowAPI.ApplicationDbContext;
using StackOverflowAPI.Entities;
using StackOverflowAPI.Interfaces;

namespace StackOverflowAPI.Repositories
{
    public class AnswerRepository : answerInterface
    {

        private readonly AppDbContext _context;
        public AnswerRepository(AppDbContext context)
        {
            _context= context;
        }
        public void addAnswer(Answer answer)
        {
           _context.answers.Add(answer);
        }

        public async Task<Answer> getAnswer(int id)
        {
           return await _context.answers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Answer>> getAnswers()
        {
          return await _context.answers.ToListAsync();
        }

        public void removeAnswer(Answer answer)
        {
           _context.answers.Remove(answer);
        }

        public async  Task<bool> saveAnswerChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
