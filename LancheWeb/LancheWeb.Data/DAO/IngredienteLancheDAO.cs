using Estoque.DAO;
using LancheWeb.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LancheWeb.Data.DAO
{
    public class IngredienteLancheDAO
    {

        public void Adiciona(IngredienteLanche inglanche)
        {
            using (var context = new LancheContext())
            {
                context.IngredienteLanche.Add(inglanche);
                context.SaveChanges();
            }
        }


        public IngredienteLanche BuscaPorId(int idIngrediente, int idLanche)
        {
            using (var contexto = new LancheContext())
            {
                return contexto.IngredienteLanche
                    .Where(p => p.IdIngrediente == idIngrediente)
                    .Where(p => p.IdLanche == idLanche)
                    .FirstOrDefault();
            }
        }

        public List<IngredienteLanche> BuscaPorLancheId(int idLanche)
        {
            using (var contexto = new LancheContext())
            {
                var ingredienteDAO = new IngredientesDAO();
                var listaIngredienteLanche =  contexto.IngredienteLanche
                    .Where(p => p.IdLanche == idLanche).ToList();

                foreach (var item in listaIngredienteLanche)
                {
                    item.Ingrediente = ingredienteDAO.BuscaPorId(item.IdIngrediente);
                }

                return listaIngredienteLanche;
            }
        }

        public void Atualiza(IngredienteLanche inglanche)
        {
            using (var contexto = new LancheContext())
            {
                contexto.Entry(inglanche).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Remove(IngredienteLanche ingLanche)
        {
            using (var contexto = new LancheContext())
            {
                contexto.Entry(ingLanche).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

    }
}
