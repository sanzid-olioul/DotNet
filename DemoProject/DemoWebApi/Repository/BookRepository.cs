using DemoWebApi.Data;
using DemoWebApi.Interface;
using Models;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _dataContext;
        public BookRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> DeleteBook(Book book)
        {
            _dataContext.Books.Remove(book);
            return await Save();
        }

        public async Task<Book> GetBook(int id)
        {
            try
            {
                var book = await _dataContext.Books.Where(b => b.Id == id).FirstOrDefaultAsync();
                return book;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            try
            {
                var books = await _dataContext.Books.ToListAsync();
                return books;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public async Task<bool> IsBookExist(int id)
        {
            return await _dataContext.Books.AnyAsync(b => b.Id == id);
        }

        public async Task<bool> CreateBook(Book book)
        {
            try
            {
                await _dataContext.Books.AddAsync(book);
                return await Save();
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateBook(Book book)
        {
            _dataContext.Books.Update(book);   
            return await Save();
        }
        public async Task<bool> Save()
        {
            var save = await _dataContext.SaveChangesAsync();
            return true ? save > 0 : false;

        }
    }
}
