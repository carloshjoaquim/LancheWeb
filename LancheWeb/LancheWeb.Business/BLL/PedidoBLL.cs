using LancheWeb.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace LancheWeb.Business.BLL
{
    public class PedidoBLL
    {
        public static PedidoViewModel MontaResumo(Lanche lanche)
        {
            var model = new PedidoViewModel();
            lanche.IngredienteLanches = IngredienteLancheBLL.BuscaPorLancheId(lanche.LancheId);
            model.Promocoes = VerificaPromocao(lanche);

            model.Nome = lanche.Nome;
            model.ValorLanche = lanche.Valor;
            model.Ingredientes = lanche.IngredienteLanches.Select(x => x.Ingrediente).ToList();
            model.ValorPedido = model.ValorLanche - model.Promocoes.Sum(x => x.Desconto);

            return model;
        }

        public static List<Promocao> VerificaPromocao(Lanche lanche)
        {
            var promocoes = new List<Promocao>();

            var muitaCarne = (lanche.IngredienteLanches.FirstOrDefault(x => x.Ingrediente.Nome.Contains("Carne")).Quantidade / 3) * 2;
            var muitoQueijo = (lanche.IngredienteLanches.FirstOrDefault(x => x.Ingrediente.Nome.Contains("Queijo")).Quantidade / 3) * 2;
            var ligth = lanche.IngredienteLanches.Any(x => x.Ingrediente.Nome.Contains("Alface")) && !lanche.IngredienteLanches.Any(x => x.Ingrediente.Nome.Contains("Bacon"));

            if (muitaCarne > 0)
            {
                promocoes.Add(new Promocao
                {
                    NomePromocao = "Muita Carne",
                    Desconto = muitaCarne * lanche.IngredienteLanches.FirstOrDefault(x => x.Ingrediente.Nome.Contains("Carne")).Ingrediente.Valor
                });
            }

            if (muitoQueijo > 0)
            {
                promocoes.Add(new Promocao
                {
                    NomePromocao = "Muito Queijo",
                    Desconto = muitaCarne * lanche.IngredienteLanches.FirstOrDefault(x => x.Ingrediente.Nome.Contains("Queijo")).Ingrediente.Valor
                });
            }

            if (ligth)
            {
                promocoes.Add(new Promocao
                {
                    NomePromocao = "Light",
                    Desconto = lanche.Valor * (decimal)0.10
                });
            }

            return promocoes;
        }

    }
}
