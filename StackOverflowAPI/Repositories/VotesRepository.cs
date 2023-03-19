using Microsoft.EntityFrameworkCore;
using StackOverflowAPI.ApplicationDbContext;
using StackOverflowAPI.Entities;
using StackOverflowAPI.Interfaces;

namespace StackOverflowAPI.Repositories
{
    public class VotesRepository : VoteInterface
    {
        private readonly AppDbContext _context;
        public VotesRepository(AppDbContext context) {
        
            _context=context;
                
        }

        public void AddVote(Vote vote)
        {
          _context.votes.Add(vote);
        }

        public async Task<Vote> CheckifVoted(int userID, int answerid)
        {
            return await _context.votes.Where(x => x.UserId == userID && x.AnswerId == answerid).FirstOrDefaultAsync();
        }

        public void deleteVotes(Vote vote)
        {
           _context.votes.Remove(vote);
        }

      

        public async Task<Vote> getVotesByAnswerId(int id)
        {
            return await _context.votes.Where(x => x.AnswerId == id).FirstOrDefaultAsync();
        }

        public async Task<int> getVotesByAnswerIdAsync(int id)
        {
            return await _context.votes.Where(x=>x.AnswerId== id).CountAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

    }
}
