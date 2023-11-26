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
            return View();
        }
    }
}
