using Consultorio_Seguros.Models;
using Consultorio_Seguros.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Consultorio_Seguros_Two.Controllers
{
    public class PeliculasController : Controller
    {
        private IPeliculaRepository _peliculaRepository;

        public PeliculasController(IPeliculaRepository peliculaRepository)
        {
            _peliculaRepository = peliculaRepository;
        }

        // GET: PeliculasController
        public ActionResult Index()
        {
            var peliculas = _peliculaRepository.GetAll();
            return View(peliculas);
        }

        // GET: PeliculasController/Details/5
        public ActionResult Details(int id)
        {
            var peliculas = _peliculaRepository.GetById(id);
            return View(peliculas);
        }

        // GET: PeliculasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeliculasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pelicula pelicula)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _peliculaRepository.Insert(pelicula);
                    TempData["successMessage"] = "Pelicula agregada correctamente.";
                    return RedirectToAction("Index");
                }
                return View(pelicula);
            }
            catch
            {
                return View();
            }
        }

        // GET: PeliculasController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var peliculas = _peliculaRepository.GetById(id);
            return View(peliculas);
        }

        // POST: PeliculasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pelicula pelicula, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _peliculaRepository.Update(pelicula, id);
                    TempData["successMessage"] = "Datos actualizados correctamente.";
                    return RedirectToAction(nameof(Index));

                }
                return View(pelicula);
                
            }
            catch
            {
                return View();
            }
        }

        // GET: PeliculasController/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var peliculas = _peliculaRepository.GetById(id);
            return View(peliculas);
        }

        // POST: PeliculasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Pelicula pelicula, int id)
        {
            
                _peliculaRepository.Delete(pelicula, id);
                TempData["successMessage"] = "Pelicula elimiada correctamente.";
                return RedirectToAction("Index");

        }
    }
}
