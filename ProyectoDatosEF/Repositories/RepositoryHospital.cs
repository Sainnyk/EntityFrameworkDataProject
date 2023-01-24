using ProyectoDatosEF.Data;
using ProyectoDatosEF.Models;

namespace ProyectoDatosEF.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;
        public RepositoryHospital(HospitalContext context) 
        {
            this.context = context;

        }

        //Creamos nuestros metodos de consulta
        public List<Hospital> GetHospitales()
        {
            var consulta = from datos in this.context.Hospitales select datos;
            return consulta.ToList();
        }

        public Hospital FindHospital(int id)
        {
            var consulta = from datos in this.context.Hospitales
                           where datos.IdHospital == id
                           select datos;
            //Como solamente devuelve un hospital podemos usar el metodo .First() o el metodo .FirstOrDefault()
            return consulta.FirstOrDefault();
        }

        
    }
}
