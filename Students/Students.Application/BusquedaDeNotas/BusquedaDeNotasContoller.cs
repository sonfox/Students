using Students.Domain.BusquedaDeNotas;
using Students.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Application.BusquedaDeNotas
{
    public class BusquedaDeNotasContoller
    {
        public List<RespuestaBusquedaDeNotas> Buscar(ParametroBusquedaDeNotas filtros)
        {
           ValidarParametros(filtros); 

            var db = new StudentsDBEntities();



            var consulta = from f in db.Grades
                           join nam in db.Subjects on f.SubjectId equals nam.Id
                           join l in db.Students on f.StudentId equals l.Id
                            select new RespuestaBusquedaDeNotas
                            {
                                NotaId = f.Id,
                                Materia = nam.Name,
                                Nota = f.GradeNumber,
                                Fecha = f.GradeDate,
                                TipoExamen = f.GradeType


                            };

            var resultados = consulta.ToList();
            return resultados;

        }

        private void ValidarParametros(ParametroBusquedaDeNotas filtros)
        {
            if (filtros == null)
                throw new NotImplementedException();
        }
    }
}
