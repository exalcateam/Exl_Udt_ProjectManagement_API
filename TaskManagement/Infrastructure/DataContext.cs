using Microsoft.EntityFrameworkCore;
using TaskManagement.Model;

namespace TaskManagement.Infrastructure
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Signuplogin> Signuplogins { get; set; }
        public DbSet<ProjectTable> ProjectTables { get; set; }
    }
}
