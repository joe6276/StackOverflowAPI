using Microsoft.EntityFrameworkCore;
using StackOverflowAPI.ApplicationDbContext;
using StackOverflowAPI.Entities;
using StackOverflowAPI.Interfaces;

namespace StackOverflowAPI.Repositories
{
    public class CommentRepository : commentInterface
    {
        private readonly AppDbContext _context;
        public CommentRepository(AppDbContext context)
        {
            _context= context;
        }

        public void AddComment(Comment comment)
        {
           _context.comments.Add(comment);
        }

        public void deleteCommentAsync(Comment comment)
        {
           _context.comments.Remove(comment);
        }

        public async Task<Comment> GetCommentAsync(int id)
        {
           return await _context.comments.FindAsync(id);
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync()
        {
            return await _context.comments.ToListAsync();
        }

        public async Task<bool> saveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
