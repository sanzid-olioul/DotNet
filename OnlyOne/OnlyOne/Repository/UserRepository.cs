using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OnlyOne.Data;
using OnlyOne.Interface;
using OnlyOne.Models;

namespace OnlyOne.Repository
{
    public class UserRepository:IUserRepository
    {
        DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<User>> GetUsers()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> CreateUser(User user)
        {
            try
            {
                await _context.AddAsync(user);

                return await Save();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteUser(User user)
        {
            try
            {
                _context.Remove(user);
                return await Save();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<User> GetUser(int id)
        {
            try
            {
                return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                _context.Update(user);
                return await Save();
            }
            catch (Exception ex)
            {
                return false;
            }
             
        }

        public async Task<bool> UserExists(int id)
        {
            try
            {
                return await _context.Users.AnyAsync(u => u.Id == id);
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> Save()
        {
            try {
                var saved =await _context.SaveChangesAsync();
                return saved > 0 ? true : false;
                }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<User> GetUserByName(string name)
        {
            try
            {
                var user = await _context.Users.Where(u => u.Name == name).FirstOrDefaultAsync();
                return user;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
