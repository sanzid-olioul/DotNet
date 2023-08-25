using BookReviewApi.Data;
using BookReviewApi.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Models;

namespace BookReviewApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _dbContext;
        public BookRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Book>> GetBooks()
        {
            try
            {
                return await _dbContext.Books.ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<Book>();
            }
            
        }
        public async Task<Book> GetBook(int id)
        {
            try
            {
                return await _dbContext.Books.Where(b => b.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                return new Book();
            }
            
        }
        public async Task<Book> CreateBook(Book book)
        {
            try
            {
                await _dbContext.Books.AddAsync(book);
                await Save();
                return book;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteBook(int id)
        {
            try
            {
                var book = await _dbContext.Books.FindAsync(id);
                if(book != null)
                {
                    _dbContext.Books.Remove(book);
                    return await Save();
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        

        

        public async Task<bool> IsBookExists(int id)
        {
            try
            {
                return await _dbContext.Books.AnyAsync(b => b.Id == id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<bool> UpdateBook(Book book)
        {
            try
            {
                _dbContext.Books.Update(book);
                return await Save();
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> Save()
        {
            var res = await _dbContext.SaveChangesAsync();
            return res > 0 ? true : false;
        }
    }
}
