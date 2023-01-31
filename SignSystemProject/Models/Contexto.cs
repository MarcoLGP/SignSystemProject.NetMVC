using Microsoft.EntityFrameworkCore;
using SignSystemProject.Models.entities;

namespace SignSystemProject.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options) 
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
