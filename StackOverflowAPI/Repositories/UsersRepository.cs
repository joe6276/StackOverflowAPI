using Microsoft.EntityFrameworkCore;
using StackOverflowAPI.ApplicationDbContext;
using StackOverflowAPI.Entities;
using StackOverflowAPI.Interfaces;
using StackOverflowAPI.Repositories.Pagination;

namespace StackOverflowAPI.Repositories
{
    public class UsersRepository : UserInterface
    {
        AppDbContext _context;
        public UsersRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddUserAsync(User user)
        {
           _context.users.Add(user);
        }

        public async Task<User> GetUserAsync(int id)
        {
         return await _context.users.FindAsync(id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.users.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async  Task<User> GetUserByResetTokenAsync(string token)
        {
            return await _context.users.Where(x => x.PasswordResetToken == token).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByTokenAsync(string token)
        {

            return await _context.users.Where(x => x.VerificationToken == token).FirstOrDefaultAsync();
        }

        public async Task<(IEnumerable<User>, PaginationMetadata)> GetUsersAsync(int pageNumber, int pageSize)
        {
         var collection= await _context.users.Skip((pageNumber-1)* pageSize).Take(pageSize).ToListAsync();
         var totalUser= await _context.users.CountAsync();
         var pagination= new PaginationMetadata(totalUser, pageSize, pageNumber);
         
            return (collection, pagination);
        }

        public void RemoveUserAsync(User user)
        {
            _context.users.Remove(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
