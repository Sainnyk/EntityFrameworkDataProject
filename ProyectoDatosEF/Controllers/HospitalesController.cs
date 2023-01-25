using Microsoft.AspNetCore.Mvc;
using ProyectoDatosEF.Models;
using ProyectoDatosEF.Repositories;

namespace ProyectoDatosEF.Controllers
{
    public class HospitalesController : Controller
    {
        private RepositoryHospital repo;
        public HospitalesController(RepositoryHospital repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            //Devolvemos todos los hospitales
            List<Hospital> hospitales = this.repo.GetHospitales();
            return View(hospitales);
        }

        public IActionResult Details(int id)
        {
            Hospital hospital = this.repo.FindHospital(id);
            return View(hospital);
        }

        public IActionResult ConsultasAccion()
        {
            List<Hospital> hospitales = this.repo.GetHospitales();
            return View(hospitales);
        }
        [HttpPost]
        public IActionResult ConsultasAccion(int idhospital,string accion)
        {

            if(accion.ToUpper() == "INSERT")
            {
                this.repo.InsertHospital(idhospital);

            }else if (accion.ToUpper() == "DELETE")
            {
                this.repo.DeleteHospital(idhospital);

            }else if (accion.ToUpper() == "UPDATE")
            {
                this.repo.UpdateHospital(idhospital);
            }
            List<Hospital> hospitales = this.repo.GetHospitales();
            return View(hospitales);
        }
    }
}
