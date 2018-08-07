using Estoque.DAO;
using LancheWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LancheWeb.DAO
{
    public class IngredientesDAO
    {

        public void Adiciona(Ingrediente ingrediente)
        {
            using (var context = new LancheContext())
            {
                context.Ingredientes.Add(ingrediente);
                context.SaveChanges();
            }
        }

        public IList<Ingrediente> Lista()
        {
            using (var contexto = new LancheContext())
            {
                return contexto.Ingredientes.Include("Ingredientes").ToList();
            }
        }

        public Ingrediente BuscaPorId(int id)
        {
            using (var contexto = new LancheContext())
            {
                return contexto.Ingredientes.Include("Ingredientes")
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
            }
        }

        public void Atualiza(Ingrediente ingrediente)
        {
            using (var contexto = new LancheContext())
            {
                contexto.Entry(ingrediente).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

    }
}
