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

        public IEnumerable<Ingrediente> Lista()
        {
            using (var contexto = new LancheContext())
            {
                return contexto.Ingredientes.ToList();
            }
        }

        public Ingrediente BuscaPorId(int id)
        {
            using (var contexto = new LancheContext())
            {
                return contexto.Ingredientes
                    .Where(p => p.IngredienteId == id)
                    .FirstOrDefault();
            }
        }

        public IEnumerable<Ingrediente> BuscaPorLancheId(int id)
        {
            using (var contexto = new LancheContext())
            {
                return contexto.IngredienteLanche
                    .Where(x => x.IdLanche == id)
                    .Select(x => x.Ingrediente)
                    .ToList();                    
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

        public void Remove(Ingrediente ingrediente)
        {
            using (var contexto = new LancheContext())
            {
                contexto.Entry(ingrediente).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

    }
}
