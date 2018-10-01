using LancheWeb.DAO;
using LancheWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LancheWeb.Controllers
{
    public class PedidoController : Controller
    {
        /*
          1. Exibir lanches do cardápio.
          2. Selecionar Lanche.
          3. Alterar ingredientes Lanche.
             3.1. Incluir novo Lanche.
          4. Finalizar Pedido.
        */



        public ActionResult Index()
        {
            // 1. Exibir Cardábio de Lanches.
            var dao = new LanchesDAO();
            var lanches = dao.ListaCompleto();
            ViewBag.Lanches = lanches;

            return View(lanches);
        }

        public ActionResult DetalheLanche(Lanche lanche)
        {
            // 2.Selecionar Lanche
            var dao = new IngredienteLancheDAO();

            lanche.IngredienteLanches = dao.BuscaPorLancheId(lanche.LancheId);

            return View(lanche);
        }

        public ActionResult ResumoPedido(Lanche lanche)
        {
            var model = new PedidoViewModel();
            var dao = new IngredienteLancheDAO();
            lanche.IngredienteLanches = dao.BuscaPorLancheId(lanche.LancheId);
            model.Promocoes = VerificaPromocao(lanche);

            model.Nome = lanche.Nome;
            model.ValorLanche = lanche.Valor;
            model.Ingredientes = lanche.IngredienteLanches.Select(x => x.Ingrediente).ToList();
            model.ValorPedido = model.ValorLanche - model.Promocoes.Sum(x => x.Desconto);



            return View(model);
        }      

        public ActionResult EscolherIngrediente(Lanche lanche)
        {

            // 3.Alterar ingredientes Lanche.

            ViewBag.Lanche = lanche;

            var dao = new IngredientesDAO();
            var ingredientesDisponiveis = dao.Lista().Where(i => i.Quantidade > 0);



            return View();
        }

        [HttpPost]
        public JsonResult Incluir(Lanche lanche)
        {

            if (ModelState.IsValid)
            {
                var dao = new LanchesDAO();
                dao.Adiciona(lanche);

                return Json(new { lanche.LancheId });

            }
            else
            {
                ViewBag.Lanche = lanche;

                return Json("Erro");
            }
        }

        public ActionResult Editar(Lanche lanche)
        {
            var ingredientes = new IngredientesDAO().Lista();
            var ingredientesLanche = getIngredientesLanche(lanche.LancheId);
            var listIngredientes = new List<Ingrediente>();

            foreach (var item in ingredientes)
            {
                listIngredientes.Add(
                                 new Ingrediente
                                 {
                                     IngredienteId = item.IngredienteId,
                                     Nome = item.Nome,
                                     Valor = item.Valor,
                                     Quantidade = ingredientesLanche.Where(x => x.IdIngrediente == item.IngredienteId).
                                                  FirstOrDefault() != null ?
                                                  ingredientesLanche.Where(x => x.IdIngrediente == item.IngredienteId).
                                                  FirstOrDefault().Quantidade :
                                                  0
                                 }
                    );
            }

            ViewBag.Ingredientes = listIngredientes;

            return View(lanche);
        }

        [HttpPut]
        public JsonResult EditaLanche(Lanche lanche)
        {

            var dao = new LanchesDAO();
            dao.Atualiza(lanche);

            return Json(new { lanche.LancheId });
        }

        public ActionResult Excluir(Lanche lanche)
        {
            var ingredientesLanche = getIngredientesLanche(lanche.LancheId);
            var ildao = new IngredienteLancheDAO();
            var lanchedao = new LanchesDAO();

            foreach (var item in ingredientesLanche)
            {
                ildao.Remove(item);
            }

            lanchedao.Remove(lanche);
            return RedirectToAction("Index");

        }


        private List<IngredienteLanche> getIngredientesLanche(int idLanche)
        {
            return new IngredienteLancheDAO().BuscaPorLancheId(idLanche);
        }

        private List<Promocao> VerificaPromocao(Lanche lanche)
        {
            var promocoes = new List<Promocao>();

            var muitaCarne = (lanche.IngredienteLanches.Where(x => x.Ingrediente.Nome.Contains("Carne")).FirstOrDefault().Quantidade / 3) * 2;
            var muitoQueijo = (lanche.IngredienteLanches.Where(x => x.Ingrediente.Nome.Contains("Queijo")).FirstOrDefault().Quantidade / 3) * 2;
            var ligth = lanche.IngredienteLanches.Any(x => x.Ingrediente.Nome.Contains("Alface")) && !lanche.IngredienteLanches.Any(x => x.Ingrediente.Nome.Contains("Bacon"));

            if (muitaCarne > 0)
            {
                promocoes.Add(new Promocao
                {
                    NomePromocao = "Muita Carne",
                    Desconto = muitaCarne * lanche.IngredienteLanches.Where(x => x.Ingrediente.Nome.Contains("Carne")).FirstOrDefault().Ingrediente.Valor
                });
            }

            if (muitoQueijo > 0)
            {
                promocoes.Add(new Promocao
                {
                    NomePromocao = "Muito Queijo",
                    Desconto = muitaCarne * lanche.IngredienteLanches.Where(x => x.Ingrediente.Nome.Contains("Queijo")).FirstOrDefault().Ingrediente.Valor
                });
            }

            if (muitoQueijo > 0)
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
