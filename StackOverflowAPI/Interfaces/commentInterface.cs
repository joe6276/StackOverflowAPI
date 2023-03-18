using StackOverflowAPI.Entities;

namespace StackOverflowAPI.Interfaces
{
    public interface commentInterface
    {
       public Task<IEnumerable<Comment>> GetCommentsAsync();

        public Task<Comment> GetCommentAsync(int id);


        public Task<bool> saveChangesAsync();

        public void deleteCommentAsync(Comment comment);

        public void AddComment (Comment comment);
    }
}
