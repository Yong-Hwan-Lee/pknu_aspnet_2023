using aspnet01_webapp.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnet01_webapp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Board> Boards { get; set; }
    }
}
