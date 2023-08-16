﻿using Microsoft.EntityFrameworkCore;
using Models;
namespace DemoWebApi.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }

    }
}
