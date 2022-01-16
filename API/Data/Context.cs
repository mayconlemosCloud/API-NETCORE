using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public virtual DbSet<Cidade> Cidade { get; set; }

      
        public virtual DbSet<Cliente> Cliente { get; set; }
    }
}
