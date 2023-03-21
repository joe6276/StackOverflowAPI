using StackOverflowAPI.Entities;
using StackOverflowAPI.Repositories.Pagination;

namespace StackOverflowAPI.Interfaces
{
    public interface UserInterface
    {
        public Task<(IEnumerable<User>, PaginationMetadata)> GetUsersAsync(int pageNumber, int pageSize);

        public Task<User> GetUserAsync(int id);


        public Task<User> GetUserByTokenAsync(string token);

        public void AddUserAsync (User user);


        public void RemoveUserAsync (User user);

        public Task<bool> SaveChangesAsync();

        public Task<User> GetUserByEmail(string email);



    }
}
