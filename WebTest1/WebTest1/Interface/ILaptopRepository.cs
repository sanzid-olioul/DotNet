using WebTest1.Models;

namespace WebTest1.Interface
{
    public interface ILaptopRepository
    {
        public Task<ICollection<Laptop>> GetLaptops();
        public Task<Laptop> GetLaptop(int id);
        public Task<Laptop> GetLaptopByName(string name);
        public Task<bool> CreateLaptop(Laptop laptop);
        public Task<bool> UpdateLaptop(Laptop laptop);
        public Task<bool> DeleteLaptop(Laptop laptop);
        public Task<bool> LaptopExists(int id);
        public Task<bool> Save();
    }
}
