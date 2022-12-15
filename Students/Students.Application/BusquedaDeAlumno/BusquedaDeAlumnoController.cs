using Students.Domain.Entities.BusquedaDeAlumnos;
using Students.Persistence.Data;
using Students.Persistence.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Students.Application.BusquedaDeAlumno
{
    public class BusquedaDeAlumnoController
    {
        public List<RespuestaBusquedaDeAlumno> Buscar(ParametroBusquedaDeAlumno filtros)

        {

            ValidaParametros(filtros);

            var db = new StudentsDBEntities();


            //consulta sin where, trae todo de la tabla students
            var consulta = from d in db.Students
                           select d;
            

            var resultados = from d in consulta
                             select new RespuestaBusquedaDeAlumno
                             {
                                 AlumnoId = d.Id,
                                 AlumnoName = d.Name,
                                 Mail = d.Email,
                                 YearDeInicio = d.EnrollmentYear,
                                 YearDeGraduacion = d.GraduationYear,
                                 Promedio = d.Average

                             };
            // agrego los where según corresponda

           // if (!string.IsNullOrWhiteSpace(filtros.Alumno))
               // consulta = from q in consulta where q.Name.Contains(filtros.Alumno) select q;

            if (filtros.Alumno != null)
                consulta = from q in consulta
                           where q.Name.Contains(filtros.Alumno)
                           select q;

            if (filtros.EstaGraduado != null)
                if (filtros.EstaGraduado == true)
                    consulta = from q in consulta where q.GraduationYear != null select q;
                else
                    consulta = from q in consulta where q.GraduationYear == null select q;

            if (filtros.YearDeGraduciaon != null)
                consulta =  from q in consulta
                            where q.GraduationYear == filtros.YearDeGraduciaon.Value
                            select q;

            if (filtros.YearDeInicio != null)
                consulta = from q in consulta
                           where q.EnrollmentYear == filtros.YearDeInicio.Value
                           select q;

            if (filtros.Promedio != null)
                consulta = from q in consulta
                           where q.Average >= filtros.Promedio.Value
                           select q;


            return resultados.ToList();

           
        }

        private void ValidaParametros(ParametroBusquedaDeAlumno filtros)
        {
            if (filtros == null)
                throw new BusquedaSinParametrosException();

            if (filtros.Alumno == string.Empty && filtros.EstaGraduado == null
                && filtros.YearDeGraduciaon == null && filtros.YearDeInicio == null
                && filtros.Promedio == null)
                throw new BusquedaSinParametrosException();
        }
    }
}




        
    

