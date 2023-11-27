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
        private ISeguroRepository _repository;

        public SegurosController(ISeguroRepository rep)
        {
            this._repository = rep;
        }

        public IActionResult Index()
        {
            var list = _repository.GetAll();
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
                _repository.Insert(seguro);
                TempData["successMessage"] = "Dato creado correctamente.";
                return RedirectToAction("Index");
            }

            return View(seguro);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {            
            var seguro = _repository.GetById(id);
            return View(seguro);
        }

        [HttpPost]
        public IActionResult Edit(int id, Seguro seguro)
        {
            if (ModelState.IsValid)
            {                
                _repository.Update(id, seguro);
                TempData["successMessage"] = "Dato actualizado correctamente.";
                return RedirectToAction("Index");
            }
            return View(seguro);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var seguro = _repository.GetById(id);
            return View(seguro);
        }

        public IActionResult Delete(int id, Seguro seguro)
        {
            if (ModelState.IsValid)
            {
                _repository.Delete(id);
                TempData["successMessage"] = "Dato eliminado correctamente.";
                return RedirectToAction("Index");
            }
            return View(seguro);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var seguro = _repository.GetById(id);
            return View(seguro);
        }
    }
}
