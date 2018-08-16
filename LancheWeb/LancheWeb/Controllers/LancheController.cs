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

    }
}
