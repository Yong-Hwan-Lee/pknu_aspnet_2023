using aspnet02_boardapp.Models;
using aspnet03_portfolioWebApp.Models;
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

        // 포트폴리오를 DB로 관리하기 위한 모델
       public DbSet<PortfolioModel> Portfolios { get; set; }

        // 포트폴리오를 DB로 관리하기 위한 모델
       //public DbSet<aspnet03_portfolioWebApp.Models.TempPortfolioMoel>? TempPortfolioMoel { get; set; }
    }
}
