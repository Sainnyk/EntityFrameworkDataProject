using Microsoft.AspNetCore.Mvc;
using ProyectoDatosEF.Models;
using ProyectoDatosEF.Repositories;

namespace ProyectoDatosEF.Controllers
{
    public class PlantillasController : Controller
    {
        RepositoryPlantilla repo;
        public PlantillasController(RepositoryPlantilla repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<Plantilla> plantillaTotal = this.repo.GetPlantilla();
            return View(plantillaTotal);
        }

        public IActionResult Details(int idempleado)
        {
            Plantilla plantilla = this.repo.GetEmpleado(idempleado);
            return View(plantilla);
        }

        public IActionResult EmpleadosPlantilla(int idhospital)
        {
            List<Plantilla> listado = this.repo.GetPlantillaHospital(idhospital);
            return View(listado);
        }

        public IActionResult BuscarPlantillaPorFuncion()
        {
            List<Plantilla> plantillaTotal = this.repo.GetPlantilla();
            ViewData["FUNCIONES"] = this.repo.GetFunciones();
            return View(plantillaTotal);
        }
        [HttpPost]
        public IActionResult BuscarPlantillaPorFuncion(string funcion)
        {
            List<Plantilla> plantilla = this.repo.GetPlantillaFuncion(funcion);
            ViewData["FUNCIONES"] = this.repo.GetFunciones();
            return View(plantilla);
        }
    }
}
