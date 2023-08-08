using OnlyOne.Models;

namespace OnlyOne.Interface
{
    public interface IUserRepository
    {
        public Task<ICollection<User>> GetUsers();
        public Task<User> GetUser(int id);
        public Task<bool> CreateUser(User user);
        public Task<bool> UpdateUser(User user);
        public Task<bool> DeleteUser(User user);
        public Task<bool> UserExists(int id);
        public Task<bool> Save();
        Task<User> GetUserByName(string name);
    }

}

