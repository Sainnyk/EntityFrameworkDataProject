using ProyectoDatosEF.Data;
using ProyectoDatosEF.Models;

namespace ProyectoDatosEF.Repositories
{
    public class RepositoryPlantilla
    {
        private HospitalContext context;

        public RepositoryPlantilla(HospitalContext context)
        {
            this.context = context;
        }

        public List<Plantilla> GetPlantilla()
        {
            var consulta = from datos in this.context.Plantillas select datos;
            return consulta.ToList();
        }

        public List<Plantilla> GetPlantillaHospital(int idhospital)
        {
            var consulta = from datos in this.context.Plantillas
                           where datos.IdHospital == idhospital
                           select datos;
            return consulta.ToList();
        }

        public Plantilla GetEmpleado(int idempleado)
        {
            var consulta = from datos in this.context.Plantillas
                           where datos.IdEmpleado == idempleado
                           select datos;
            return consulta.First();
        }
        public List<Plantilla> GetPlantillaFuncion(string funcion)
        {
            var consulta = from datos in this.context.Plantillas where datos.Funcion == funcion select datos;
            return consulta.ToList();
        }

        public List<String> GetFunciones()
        {
            var consulta = from datos in this.context.Plantillas select datos.Funcion;
            //var consulta = (from datos in this.context.Plantillas select datos.Funcion).Distinct();

            return consulta.Distinct().ToList();
        }
    }
}
