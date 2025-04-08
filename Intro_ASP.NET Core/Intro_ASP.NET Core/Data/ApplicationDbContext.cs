using Intro_ASP.NET_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Intro_ASP.NET_Core.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<ContactRequest> ContactRequests { get; set; } 

        public DbSet<Category> Categories { get; set; }

    }
}