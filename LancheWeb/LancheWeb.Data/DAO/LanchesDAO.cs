using LancheWeb.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LancheWeb.Data.DAO
{
    public class LanchesDAO
    {

        public void Adiciona(Lanche lanche)
        {
            using (var context = new LancheContext())
            {
                context.Lanches.Add(lanche);
                context.SaveChanges();
            }
        }

        public IList<Lanche> Lista()
        {
            using (var contexto = new LancheContext())
            {
                return contexto.Lanches.ToList();
            }
        }

        public IList<Lanche> ListaCompleto()
        {
            using (var context = new LancheContext())
            {
                var lanches = context.Lanches.ToList();
                var listLanches = new List<Lanche>();

                foreach (var lanche in lanches)
                {                    
                    lanche.IngredienteLanches = context.IngredienteLanche.Where(i => i.IdLanche == lanche.LancheId).ToList();
                    listLanches.Add(lanche);
                }

                foreach (var item in listLanches)
                {
                    foreach (var ingrediente in item.IngredienteLanches)
                    {
                        var ingredienteBD = context.Ingredientes.Where(i => i.IngredienteId == ingrediente.IdIngrediente).FirstOrDefault() ?? new Ingrediente();
                        ingrediente.Ingrediente.Valor = ingredienteBD.Valor;
                    }
                }

                return listLanches;
            }

        }

        public Lanche BuscaPorId(int id)
        {
            using (var contexto = new LancheContext())
            {
                return contexto.Lanches
                    .Where(p => p.LancheId == id)
                    .FirstOrDefault();
            }
        }

        public void Atualiza(Lanche lanche)
        {
            using (var contexto = new LancheContext())
            {
                contexto.Entry(lanche).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Remove(Lanche lanche)
        {
            using (var contexto = new LancheContext())
            {
                contexto.Entry(lanche).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

    }
}
