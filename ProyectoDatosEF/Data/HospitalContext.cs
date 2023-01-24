using Microsoft.EntityFrameworkCore;
using ProyectoDatosEF.Models;

namespace ProyectoDatosEF.Data
{
    public class HospitalContext: DbContext
    {
        //Necesitamos un constructor obligatorio para poder recibir la cadena de conexión desde program
        public HospitalContext(DbContextOptions<HospitalContext> options):base(options) { }//Es un objeto DbContextOptions que recibe un HospitalContext llamado options

        //Debemos mapear cada clase Model de la base de datos con un objeto DbSet.
        //Cada tabla de la base de datos sera un Dbset con un Model. Nosotros haremos las consultas a dicho DbSet(que es una propiedad)
        public DbSet<Hospital> Hospitales { get; set; }
        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Plantilla> Plantillas { get; set; }
    }
}
