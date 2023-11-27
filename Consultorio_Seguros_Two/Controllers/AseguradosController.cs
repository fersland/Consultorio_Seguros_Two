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
        private IAseguradoRepository _repository_asegurado;
        private IClienteRepository _repository_cliente;
        private ISeguroRepository _repository_seguro;

        public AseguradosController(IAseguradoRepository repository_asegurado, IClienteRepository repository_cliente, ISeguroRepository repository_seguro)
        {
            this._repository_asegurado = repository_asegurado;
            this._repository_cliente = repository_cliente;
            this._repository_seguro = repository_seguro;
        }

        public IActionResult Index()
        {
            var asegurado = _repository_asegurado.GetAll();
            return View(asegurado);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Clientes = _repository_cliente.GetAll();
            ViewBag.Seguros = _repository_seguro.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Asegurado asegurado)
        {
            ViewBag.Clientes = _repository_cliente.GetAll();
            ViewBag.Seguros = _repository_seguro.GetAll();

            if(asegurado is not null)
            {
                _repository_asegurado.Insert(asegurado);
                TempData["successMessage"] = "Dato guardado correctamente.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errorMessage"] = "Este seguro ya se ha guardado anteriormente.";
                return View();
            }
        }

    }
}
