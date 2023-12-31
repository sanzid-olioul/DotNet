﻿using Models;

namespace DemoClient.Services
{
    public interface IBookService
    {
        public Task<IEnumerable<Book>> GetBooks();
        public Task<Book> GetBook(int id);
        public Task<bool> CreateBook(Book book);
        public Task<bool> UpdateBook(Book book);
        public Task<bool> DeleteBook(Book book);
        public Task<bool> IsBookExist(int id);
    }
}
