using Consultorio_Seguros.Models;
using Consultorio_Seguros.Models.ViewModel;
using Consultorio_Seguros.Repositories;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Consultorio_Seguros_Two.Controllers
{
    public class AseguradosController : Controller
    {
        private IAseguradoRepo _repository;

        public AseguradosController(IAseguradoRepo rep)
        {
            this._repository = rep;
        }

        public IActionResult Index()
        {
            List<AseguradoVM> asegurados = new List<AseguradoVM>();
            var asegurado = _repository.GetAsegurados("GetAsegurados", null, CommandType.StoredProcedure);
            return View(asegurado);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Clientes = _repository.GetClientes("GetClientes", null, CommandType.StoredProcedure);
            ViewBag.Seguros = _repository.GetSeguros("GetSeguros", null, CommandType.StoredProcedure);
            return View();
        }

        [HttpPost]
        public IActionResult Create(Asegurado asegurado)
        {
            ViewBag.Clientes = _repository.GetClientes("GetClientes", null, CommandType.StoredProcedure);
            ViewBag.Seguros = _repository.GetSeguros("GetSeguros", null, CommandType.StoredProcedure);
                        
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ClienteId", asegurado.ClienteId);
            parameters.Add("@SeguroId", asegurado.SeguroId);
            _repository.DMLAsegurado("InsertAsegurado", parameters, CommandType.StoredProcedure);
            TempData["successMessage"] = "Dato guardado correctamente.";
            return RedirectToAction("Index");
        }

    }
}
