using ProyectoDatosEF.Data;
using ProyectoDatosEF.Models;

namespace ProyectoDatosEF.Repositories
{
    public class RepositoryEmpleados
    {
        private HospitalContext context;
        public RepositoryEmpleados(HospitalContext context)
        {
            this.context = context;
        }

        public List<Empleado> GetEmpleados()
        {
            var consulta = from datos in this.context.Empleados select datos;
            return consulta.ToList();
        }

        public List<String> GetFunciones()
        {
            var consulta = (from datos in this.context.Empleados select datos.Oficio).Distinct();
            return consulta.ToList();
        }

        public List<Empleado> GetEmpleadosPorFuncion(string funcion)
        {
            var consulta = from datos in this.context.Empleados where datos.Oficio == funcion select datos;
            return consulta.ToList();
        }

        public Empleado FindEmpleado(int id)
        {
            var consulta = from datos in this.context.Empleados where datos.IdEmpleado == id select datos;
            return consulta.FirstOrDefault();
        }

        public void IncrementarSalario(string funcion, int incremento)
        {
            List<Empleado> empleados = GetEmpleadosPorFuncion(funcion);
            foreach(Empleado emp in empleados)
            {
                emp.Salario += incremento;
                this.context.SaveChanges();

            }
        }

        public void DeleteEmpleado(int id)
        {
            Empleado emp = FindEmpleado(id);
            this.context.Empleados.Remove(emp);
            this.context.SaveChanges();
        }
    }
}
