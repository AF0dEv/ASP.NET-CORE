using ExCliX.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExCliX.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Tclientes { get; set; }
        public DbSet<Tipo> Ttipos { get; set; }
        public DbSet<Item> Titems { get; set; }
    }
}
