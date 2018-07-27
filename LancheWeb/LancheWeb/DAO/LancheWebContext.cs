using System;
using System.Collections.Generic;
using System.Text;
using LancheWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LancheWeb.DAO
{
    public class LancheWebContext : DbContext
    {
        private static IConfiguration _config;
        public LancheWebContext(DbContextOptions<LancheWebContext> options, IConfiguration config) : base(options) => _config = config;

        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Lanche> Lanches { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(_config.GetConnectionString("LancheWeb"));
            }
        }



    }
}
