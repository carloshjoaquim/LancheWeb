using Estoque.DAO;
using LancheWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LancheWeb.DAO
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
