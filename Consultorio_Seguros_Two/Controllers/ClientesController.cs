using Consultorio_Seguros.Models;
using Consultorio_Seguros.Repositories;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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

                _clienteRepo.DMLCliente("InsertCliente", parameters, CommandType.StoredProcedure);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            var cliente = _clienteRepo.GetClienteById("GetClienteById", parameters, CommandType.StoredProcedure);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            if(ModelState.IsValid)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", cliente.Id);
                parameters.Add("@Cedula", cliente.Cedula);
                parameters.Add("@Nombre", cliente.Nombre);
                parameters.Add("@Telefono", cliente.Telefono);
                parameters.Add("@Edad", cliente.Edad);

                _clienteRepo.DMLCliente("UpdateCliente", parameters, CommandType.StoredProcedure);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            var cliente = _clienteRepo.GetClienteById("GetClienteById", parameters, CommandType.StoredProcedure);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Delete(int id, Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                _clienteRepo.DMLCliente("DeleteCliente", parameters, CommandType.StoredProcedure);
                TempData["successMessage"] = "Dato eliminado correctamente.";
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            var cliente = _clienteRepo.GetClienteById("GetClienteById", parameters, CommandType.StoredProcedure);
            return View(cliente);
        }

    }
}
