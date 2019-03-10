using Microsoft.EntityFrameworkCore;
using APITaskList.Models;

namespace APITaskList.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Task> Task { get; set; }
    }
}