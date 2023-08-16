using Models;
namespace DemoWebApi.Interface
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> GetBooks();
        public Task<Book> GetBook(int id);
        public Task<bool> CreateBook(Book book);
        public Task<bool> UpdateBook(Book book);
        public Task<bool> DeleteBook(Book book);
        public Task<bool> IsBookExist(int id);

        public Task<bool> Save();
    }
}
