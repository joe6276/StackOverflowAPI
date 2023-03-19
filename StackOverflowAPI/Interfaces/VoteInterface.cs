using StackOverflowAPI.Entities;

namespace StackOverflowAPI.Interfaces
{
    public interface VoteInterface
    {
        Task<bool> SaveChangesAsync();

        Task<int> getVotesByAnswerIdAsync(int id);


        Task<Vote> getVotesByAnswerId(int id);  
        public void AddVote(Vote vote);

        public Task<Vote> CheckifVoted(int userID, int answerid);

        public void deleteVotes (Vote vote);

     
    }
}
