using Models;

namespace BookReviewApi.Interface
{
    public interface IBookRepository
    {
        public Task<ICollection<Book>> GetBooks();
        public Task<Book> GetBook(int id);
        public Task<Book> CreateBook(Book book);
        public Task<bool> UpdateBook(Book book);
        public Task<bool> DeleteBook(int id);
        public Task<bool> IsBookExists(int id);
        public Task<bool> Save();
    }
}
