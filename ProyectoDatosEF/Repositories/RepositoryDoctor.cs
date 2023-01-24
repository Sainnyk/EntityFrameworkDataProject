using ProyectoDatosEF.Data;
using ProyectoDatosEF.Models;

namespace ProyectoDatosEF.Repositories
{
    public class RepositoryDoctor
    {
        private HospitalContext context;

        public RepositoryDoctor(HospitalContext context)
        {
            this.context = context;
        }

        public List<Doctor> GetDoctores()
        {
            var consulta = from datos in this.context.Doctores select datos;
            return consulta.ToList();
        }

        public List<Doctor> GetDoctoresHospital(int idhospital)
        {
            var consulta = from datos in this.context.Doctores where datos.IdHospital == idhospital select datos;
            return consulta.ToList();
        }
    }
}
