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
        private IClienteRepo _repository_cliente;
        private ISeguroRepo _repository_seguro;

        public AseguradosController(IAseguradoRepo rep, IClienteRepo repository_cliente, ISeguroRepo repository_repo)
        {
            this._repository = rep;
            this._repository_cliente = repository_cliente;
            this._repository_seguro = repository_repo;
        }

        public IActionResult Index()
        {
            var asegurado = _repository.GetAsegurados("GetAsegurados", null, CommandType.StoredProcedure);
            return View(asegurado);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Clientes = _repository_cliente.GetClientes("GetClientes", null, CommandType.StoredProcedure);
            ViewBag.Seguros = _repository_seguro.GetSeguros("GetSeguros", null, CommandType.StoredProcedure);
            return View();
        }

        [HttpPost]
        public IActionResult Create(Asegurado asegurado)
        {
            ViewBag.Clientes = _repository_cliente.GetClientes("GetClientes", null, CommandType.StoredProcedure);
            ViewBag.Seguros = _repository_seguro.GetSeguros("GetSeguros", null, CommandType.StoredProcedure);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ClienteId", asegurado.ClienteId);
            parameters.Add("@SeguroId", asegurado.SeguroId);

            _repository.DMLAsegurado("InsertAsegurado", parameters, CommandType.StoredProcedure);
            TempData["successMessage"] = "Dato guardado correctamente.";
            return RedirectToAction("Index");
        }

    }
}
