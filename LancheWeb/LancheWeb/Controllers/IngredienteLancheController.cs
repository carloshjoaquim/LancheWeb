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

        [HttpPut]
        public JsonResult EditaIngredienteLanche([FromBody]IEnumerable<IngredienteLanche> ingredientes)
        {

            var dao = new IngredienteLancheDAO();
            foreach(var item in ingredientes)
            {
                if (dao.BuscaPorId(item.IdIngrediente, item.IdLanche) != null)
                    dao.Atualiza(item);
                else
                    dao.Adiciona(item);
            }

            return Json("OK");
        }
    }
}
