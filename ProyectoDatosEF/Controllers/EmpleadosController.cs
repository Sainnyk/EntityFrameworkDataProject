using Microsoft.AspNetCore.Mvc;
using ProyectoDatosEF.Models;
using ProyectoDatosEF.Repositories;

namespace ProyectoDatosEF.Controllers
{
    public class EmpleadosController : Controller
    {
        private RepositoryEmpleados repo;
        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }
        public IActionResult ListadoEmpleados()
        {
            List<Empleado> empleados = this.repo.GetEmpleados();
            ViewData["EMPLEADOS"] = this.repo.GetFunciones();
            return View(empleados);
        }
        [HttpPost]
        public IActionResult ListadoEmpleados(string funcion, int incremento)
        {
            this.repo.IncrementarSalario(funcion, incremento);
            List<Empleado> empleados = this.repo.GetEmpleadosPorFuncion(funcion);
            ViewData["EMPLEADOS"] = this.repo.GetFunciones();
            return View(empleados);
        }

        public IActionResult Delete(int id)
        {
            Empleado emp = this.repo.FindEmpleado(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Delete(Empleado emp)
        {
            this.repo.DeleteEmpleado(emp.IdEmpleado);
            return RedirectToAction("ListadoEmpleados");
        }
    }
}
