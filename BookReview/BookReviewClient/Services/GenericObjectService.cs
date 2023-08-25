using System.Net.Http.Json;

namespace BookReviewClient.Services
{

    public interface IGenericObjectService<T>
    {
        public Task<IEnumerable<T>> GetObjects(string route);
        public Task<T> GetObject(string route);
        public Task<T> CreateObject(string route, T obj);
        public Task<bool> UpdateObject(string route, T obj);
        public Task<bool> DeleteObject(string route);
    }
    public class GenericObjectService<T> : IGenericObjectService<T>
    {
        private readonly HttpClient _httpClient;
        public GenericObjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<T> CreateObject(string route,T obj)
        {
 
            var response = await _httpClient.PostAsJsonAsync(route, obj);
            return await response.Content.ReadFromJsonAsync<T>();
            
        }

        public async Task<bool> DeleteObject(string route)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(route);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<T> GetObject(string route)
        {
            var book = await _httpClient.GetFromJsonAsync<T>(route);
            return book;
        }

        public async Task<IEnumerable<T>> GetObjects(string route)
        {
            var books = await _httpClient.GetFromJsonAsync<IEnumerable<T>>("api/Book");
            return books;
        }

        public async Task<bool> UpdateObject(string route,T obj)
        {
            try
            {
                var res = await _httpClient.PutAsJsonAsync(route, obj);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
