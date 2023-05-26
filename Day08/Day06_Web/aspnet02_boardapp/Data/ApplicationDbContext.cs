using aspnet02_boardapp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace aspnet01_webapp.Data
{
    public class ApplicationDbContext : IdentityDbContext   // 1. ASP.NET Identity : Dbcontext -> IdentityContext결국 DbContext 쓰는것하고 동일
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Board> Boards { get; set; }
    }
}
