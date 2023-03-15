using Microsoft.EntityFrameworkCore;
using StackOverflowAPI.ApplicationDbContext;
using StackOverflowAPI.Entities;
using StackOverflowAPI.Interfaces;

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
            return await _context.users.FirstAsync(x => x.Email == email);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
         return  await _context.users.ToListAsync();
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
