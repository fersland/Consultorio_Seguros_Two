using Consultorio_Seguros.Models;
using Consultorio_Seguros.Repositories;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio_Seguros.Web.Controllers
{
    public class ClientesController : Controller
    {
        private IClienteRepo _clienteRepo;

        public ClientesController(IClienteRepo clienteRepo)
        {
            this._clienteRepo = clienteRepo;
        }

        public IActionResult Index()
        {
            var clientes = _clienteRepo.GetClientes("GetClientes", null, System.Data.CommandType.StoredProcedure);
            return View(clientes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            if(ModelState.IsValid)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Cedula", cliente.Cedula);
                parameters.Add("@Nombre", cliente.Nombre);
                parameters.Add("@Telefono", cliente.Telefono);
                parameters.Add("@Edad", cliente.Edad);
                _clienteRepo.DMLCliente("InsertCliente", parameters, System.Data.CommandType.StoredProcedure);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }



    }
}
