using CrudWhitRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudWhitRazor.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public virtual DbSet<Line> Lines { get; set; }
    }
}