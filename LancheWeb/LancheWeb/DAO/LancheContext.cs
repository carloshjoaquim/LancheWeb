using LancheWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Estoque.DAO
{
    public class LancheContext : DbContext
    {


        public DbSet<Ingrediente> Ingredientes { get; set; }

        public DbSet<Lanche> Lanches { get; set; }

        public DbSet<IngredienteLanche> IngredienteLanche { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfiguratioManager.ConnectionStrings["LancheDb"].ConnectionString);
        }

    }
}