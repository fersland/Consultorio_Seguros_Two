using Consultorio_Seguros.Models;
using Consultorio_Seguros.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio_Seguros_Two.Controllers
{
    public class CantantesController : Controller
    {
        private readonly ICantanteRepository _repository;

        public CantantesController(ICantanteRepository cantanteRepository)
        {
            _repository = cantanteRepository;
        }

        public IActionResult Index()
        {
            var fflush = _repository.GetAll();
            return View(fflush);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cantante cantante)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(cantante);
                TempData["successMessage"] = "Dato registrado correctamente.";
                return RedirectToAction("Index");
            }
            return View(cantante);
        }

        [HttpGet]
         public IActionResult Edit(int id)
         {
            var cantante = _repository.GetById(id);
            return View(cantante);
         }

        [HttpPost]
        public IActionResult Edit(int id, Cantante cantante)
        {
            if(ModelState.IsValid)
            {
                _repository.Update(id, cantante);
                TempData["successMessage"] = "Dato actualizado correctamente.";
                return RedirectToAction("Index");
            }
            return View(cantante);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var cantante = _repository.GetById(id);
            return View(cantante);
        }

        [HttpPost]
        public IActionResult Delete(int id, Cantante cantante)
        {
            if (ModelState.IsValid)
            {
                _repository.Delete(id);
                TempData["successMessage"] = "Dato eliminado correctamente.";
                return RedirectToAction("Index");
            }
            return View(cantante);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var cantante = _repository.GetById(id);
            return View(cantante);
        }
    }
}
