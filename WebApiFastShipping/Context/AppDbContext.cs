using Microsoft.EntityFrameworkCore;
using WebApiFastShipping.Models;

namespace WebApiFastShipping.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Conductor> Conductors { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

    }
}
