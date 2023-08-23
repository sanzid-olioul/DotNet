using Models;
using MudBlazor.Extensions;
using System.Net.Http.Json;
namespace BookReviewClient.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;
        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Book> CreateBook(Book book)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Book", book);
                return await response.Content.ReadFromJsonAsync<Book>();
            }
            catch (Exception ex)
            {
                return null;
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

        public async Task<Book> GetBook(int id)
        {
            var book = await _httpClient.GetFromJsonAsync<Book>($"api/Book/{id}");
            return book;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var books = await _httpClient.GetFromJsonAsync<IEnumerable<Book>>("api/Book");
            return books;
        }

        public async Task<bool> UpdateBook(Book book)
        {
            try
            {
                var res = await _httpClient.PutAsJsonAsync($"api/Book/{book.Id}", book);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
    }
}
