using LancheWeb.DAO;
using LancheWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LancheWeb.Controllers
{
    public class IngredienteLancheController : Controller
    {

        [HttpPost]
        public JsonResult Incluir([FromBody] IEnumerable<IngredienteLanche> ingredientes)
        {

            foreach (var il in ingredientes)
            {
                var dao = new IngredienteLancheDAO();
                dao.Adiciona(il);
            }
            return Json("OK");

        }

        [Route("detalhe/{id}", Name = "DetalheIngrediente")]
        public ActionResult Detalhe(int id)
        {
            var ingrediente = new IngredientesDAO().BuscaPorId(id);
            ViewBag.Ingrediente = ingrediente;

            return View(ingrediente);
        }

        public ActionResult Editar(Ingrediente ingrediente)
        {
            return View(ingrediente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditaIngrediente(Ingrediente ingrediente)
        {

            var dao = new IngredientesDAO();
            dao.Atualiza(ingrediente);

            return RedirectToAction("Index");
        }

        public ActionResult Excluir(Ingrediente ingrediente)
        {
            var dao = new IngredientesDAO();
            dao.Remove(ingrediente);

            return RedirectToAction("Index");

        }



    }
}
