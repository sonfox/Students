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

            if (!string.IsNullOrWhiteSpace(filtros.Alumno))
                consulta = from q in consulta where q.Name.Contains(filtros.Alumno) select q;

            if (filtros.EstaGraduado.HasValue)
                if (filtros.EstaGraduado == true)
                    consulta = from q in consulta where q.GraduationYear.HasValue select q;
                else
                    consulta = from q in consulta where q.GraduationYear.HasValue == false select q;

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




        
    

