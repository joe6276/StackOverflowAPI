using StackOverflowAPI.Entities;

namespace StackOverflowAPI.Interfaces
{
    public interface UserInterface
    {
        public Task<IEnumerable<User>> GetUsersAsync();

        public Task<User> GetUserAsync(int id);


        public void AddUserAsync (User user);


        public void RemoveUserAsync (User user);

        public Task<bool> SaveChangesAsync();

        public Task<User> GetUserByEmail(string email);

    }
}
