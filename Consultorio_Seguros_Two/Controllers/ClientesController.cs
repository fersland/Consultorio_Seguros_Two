using Consultorio_Seguros.Models;
using Consultorio_Seguros.Repositories;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Consultorio_Seguros.Web.Controllers
{
    public class ClientesController : Controller
    {
        private IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepo)
        {
            this._clienteRepository = clienteRepo;
        }

        public IActionResult Index()
        {
            var clientes = _clienteRepository.GetAll();
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
                _clienteRepository.Insert(cliente);
                TempData["successMessage"] = "Dato registrado correctamente.";
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cliente = _clienteRepository.GetById(id);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(int id, Cliente cliente)
        {
            if(ModelState.IsValid)
            {
                _clienteRepository.Update(id, cliente);
                TempData["successMessage"] = "Dato actualizado correctamente.";
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var cliente = _clienteRepository.GetById(id);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Delete(int id, Cliente cliente)
        {
            if (ModelState.IsValid)
            {                
                _clienteRepository.Delete(id);
                TempData["successMessage"] = "Dato eliminado correctamente.";
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var cliente = _clienteRepository.GetById(id);
            return View(cliente);
        }

    }
}