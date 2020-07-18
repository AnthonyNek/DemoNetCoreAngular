using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Modelos
{
    public class BDPruebaContext:DbContext
    {
        public BDPruebaContext()
        {

        }
        public BDPruebaContext(DbContextOptions<BDPruebaContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source = tcp:sl2020.database.windows.net; initial catalog = BDInventario1; user id = prueba; password = Pa$$w0rd2019");
            }
        }
    }
}
