using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Califi_restaurante.Models.Data
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options){        }

        //propiedades para cada entidad
        public DbSet<tbl_Datos> Datos { get; set; }
        public DbSet<tbl_Restaurantes> Restaurantes { get; set; }
        public DbSet<tbl_Roles> Roles { get; set; }
        public DbSet<tbl_Usuarios> Usuarios { get; set; }
        public DbSet<tbl_Votaciones> Votaciones { get; set; }
    }
}
