using Consultorio_Seguros.Models;
using Consultorio_Seguros.Repositories;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Text.Json.Serialization.Metadata;

namespace Consultorio_Seguros_Two.Controllers
{
    public class SegurosController : Controller
    {
        private ISeguroRepo _repository;

        public SegurosController(ISeguroRepo rep)
        {
            this._repository = rep;
        }

        public IActionResult Index()
        {
            var list = _repository.GetSeguros("GetSeguros", null, CommandType.StoredProcedure);
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Seguro seguro)
        {
            if(ModelState.IsValid)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Codigo", seguro.Codigo);
                parameters.Add("@Nombre", seguro.Nombre);
                parameters.Add("@Asegurada", seguro.Asegurada);
                parameters.Add("@Prima", seguro.Prima);
                _repository.DMLSeguro("InsertSeguro", parameters, CommandType.StoredProcedure);
                TempData["successMessage"] = "Dato creado correctamente.";
                return RedirectToAction("Index");
            }

            return View(seguro);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            var seguro = _repository.GetSeguroById("GetSeguroById", parameters, CommandType.StoredProcedure);
            return View(seguro);
        }

        public IActionResult Edit(Seguro seguro)
        {
            if (ModelState.IsValid)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", seguro.Id);
                parameters.Add("@Codigo", seguro.Codigo);
                parameters.Add("@Nombre", seguro.Nombre);
                parameters.Add("@Asegurada", seguro.Asegurada);
                parameters.Add("@Prima", seguro.Prima);
                _repository.DMLSeguro("UpdateSeguro", parameters, CommandType.StoredProcedure);
                TempData["successMessage"] = "Dato actualizado correctamente.";
                return RedirectToAction("Index");
            }
            return View(seguro);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            var seguro = _repository.GetSeguroById("GetSeguroById", parameters, CommandType.StoredProcedure);
            return View(seguro);
        }

        public IActionResult Delete(int id, Seguro seguro)
        {
            if (ModelState.IsValid)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                _repository.DMLSeguro("DeleteSeguro", parameters, CommandType.StoredProcedure);
                TempData["successMessage"] = "Dato eliminado correctamente.";
                return RedirectToAction("Index");
            }
            return View(seguro);
        }
    }
}
