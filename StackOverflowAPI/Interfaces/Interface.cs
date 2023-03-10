using StackOverflowAPI.Entities;

namespace StackOverflowAPI.Interfaces
{
    public interface UserInterface
    {
        public Task<User> GetUsersAsync();
    }
}
