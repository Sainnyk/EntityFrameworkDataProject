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

        public void InsertHospital(int idhospital)
        {
            //1º Creamos un nuevo objeto de tipo Hospital
            Hospital hospital = new Hospital();
            hospital.IdHospital= idhospital;
            hospital.Nombre = "NUEVO"; //inventado
            hospital.Telefono = "NUEVO";
            hospital.Camas = 99;
            hospital.Direccion = "Calle Nueva";
            
            this.context.Hospitales.Add(hospital);
            this.context.SaveChanges();
        }

        public void DeleteHospital(int idhospital)
        {
            Hospital hospital = FindHospital(idhospital);
            this.context.Hospitales.Remove(hospital);
            this.context.SaveChanges();
        }

        public void UpdateHospital(int idhospital)
        {
            Hospital hospital = FindHospital(idhospital);
            hospital.Nombre = "ACTUALIZADO"; //inventado
            hospital.Telefono = "ACTUALIZADO";
            hospital.Camas = 99;
            hospital.Direccion = "Calle Actualizada";
            this.context.SaveChanges();
        }

        
    }
}
