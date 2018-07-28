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

        public LancheWebContext(DbContextOptions<LancheWebContext> options) 
            : base(options)
        { }


        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Lanche> Lanches { get; set; }

    }
}
