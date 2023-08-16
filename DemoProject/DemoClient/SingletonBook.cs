using Models;
namespace DemoClient
{
    public class SingletonBook
    {
        public List<Book> BookList = new List<Book>();
        public void AddBook(Book book)
        {
            BookList.Add(book);
        }
        public void RemoveBook(Book book)
        {
            BookList.Remove(book);
        }

        public void UpdateBook(Book book)
        {
            return;
        }

    }
}
