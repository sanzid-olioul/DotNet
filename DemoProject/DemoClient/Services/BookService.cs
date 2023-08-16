using Models;
using System.Net.Http.Json;

namespace DemoClient.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;
        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> CreateBook(Book book)
        {
            try
            {
                await _httpClient.PostAsJsonAsync("api/Book", book);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public async Task<bool> DeleteBook(Book book)
        {
            try
            {
                var response = await _httpClient.DeleteAsync("api/Book/" + book.Id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public Task<Book> GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<Book>>("/api/Book");
            }catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        public Task<bool> IsBookExist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateBook(Book book)
        {
            await _httpClient.PutAsJsonAsync($"api/Book/{book.Id}", book);
            return true;
        }
    }
}
