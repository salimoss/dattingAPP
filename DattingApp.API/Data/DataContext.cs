using DattingApp.API.Model;
using Microsoft.EntityFrameworkCore;

namespace DattingApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}
        public DbSet<Value> values {get; set;}
        public DbSet<User> Users {get;set;}
        public DbSet<Photo> Photos { get; set; }
    }
}