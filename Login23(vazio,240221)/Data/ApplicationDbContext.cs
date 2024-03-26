using Microsoft.EntityFrameworkCore;

using Login23.Models;
namespace Login23.Data
{
    public class ApplicationDbContext :DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options )
            : base( options )   
        {
            
        }

        public DbSet<Utilizador> TUtilizadores { get; set; }





    }
}

