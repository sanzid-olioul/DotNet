using Microsoft.EntityFrameworkCore;
using WebTest1.Data;
using WebTest1.Interface;
using WebTest1.Models;

namespace WebTest1.Repository
{
    public class LaptopRepository:ILaptopRepository
    {
        private readonly DataContext _dbContext;
        public LaptopRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Laptop>> GetLaptops()
        {
            return await _dbContext.Laptops.ToListAsync();
        }
        public async Task<Laptop> GetLaptop(int id)
        {
            try
            {
                if(await LaptopExists(id))
                {
                    return await _dbContext.Laptops.Where(l => l.Id == id).FirstOrDefaultAsync();
                }
                return null;
                
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public async Task<Laptop> GetLaptopByName(string name)
        {
            try
            {
                return await _dbContext.Laptops.Where(l => l.Name == name).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<bool> CreateLaptop(Laptop laptop)
        {
            try
            {
                await _dbContext.Laptops.AddAsync(laptop);
                return await Save();
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateLaptop(Laptop laptop)
        {
            try
            {
                _dbContext.Laptops.Update(laptop);
                return await Save();
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteLaptop(Laptop laptop)
        {
            try
            {
                _dbContext?.Laptops.Remove(laptop);
                return await Save();
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> LaptopExists(int id)
        {
            try
            {
                return await _dbContext.Laptops.AnyAsync(l=>l.Id==id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> Save()
        {
            try
            {
                var saved = await _dbContext.SaveChangesAsync();
                return saved > 0 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
