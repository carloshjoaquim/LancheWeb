using LancheWeb.DAO;
using LancheWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LancheWeb.Controllers
{
    public class LancheController : Controller
    {
        // GET: Produto
        [Route("lanche", Name = "ListaLanches")]
        public ActionResult Index()
        {
            var dao = new LanchesDAO();
            var lanches = dao.Lista();
            ViewBag.Lanches = lanches;

            return View(lanches);
        }

        public ActionResult Cadastrar()
        {
            var dao = new IngredientesDAO();
            ViewBag.Ingredientes = dao.Lista();
            ViewBag.Lanches = new Lanche();


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
            var ingredientesLanche = new IngredienteLancheDAO().BuscaPorLancheId(lanche.LancheId);
            var listIngredientes = new List<Ingrediente>();

            foreach (var item in ingredientes)
            {
                listIngredientes.Add(
                                 new Ingrediente
                                 {
                                     IngredienteId = item.IngredienteId,
                                     Nome = item.Nome,
                                     Valor = item.Valor,
                                     Quantidade = ingredientesLanche.Where(x => x.IdIngrediente == item.IngredienteId).FirstOrDefault()?.Quantidade
                                 }
                    );
            }

            ViewBag.Ingredientes = listIngredientes;

            return View(lanche);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditaIngrediente(Ingrediente ingrediente)
        {

            var dao = new IngredientesDAO();
            dao.Atualiza(ingrediente);

            return RedirectToAction("Index");
        }

        public ActionResult Excluir(Lanche lanche)
        {
            var dao = new LanchesDAO();
            dao.Remove(lanche);

            return RedirectToAction("Index");

        }



    }
}
