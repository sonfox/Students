using Students.Domain.Entities.GravarAlumno;
using Students.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Students.Application.GrabarAlumno
{
    public class GrabarAlumnoController
    {

        public int GrabarAlumno  (ParametrosAlumnoAGrabar alumno )
        {
            var db = new StudentsDBEntities();

            Validar(alumno, db);

            var FDb = db.Students.Create();
            FDb.Name = alumno.Alumno;
            FDb.Average = (Decimal)alumno.Promedio;
            FDb.EnrollmentYear = DateTime.Today; 
            FDb.GraduationYear = alumno.YearDeGraduciaon;
            FDb.Email= alumno.Mail.ToLower();
            db.Students.Add( FDb );
            db.SaveChanges();

            int NuevoId = FDb.Id;
            return NuevoId;




        }

        private void Validar(ParametrosAlumnoAGrabar alumno, StudentsDBEntities db)
        {
            
            if (alumno.Alumno == null)
                throw new NotImplementedException("No se Ingreso ningun nombre");
            if (alumno.Mail != null)
            {
                var m = (from c in db.Students
                         where c.Email == alumno.Mail
                         select c);
                if (m != null)
                    throw new KeyNotFoundException("el mail ya existe");

            }




        }
    }
}
