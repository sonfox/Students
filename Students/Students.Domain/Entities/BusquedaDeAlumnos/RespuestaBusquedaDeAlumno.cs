using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.Entities.BusquedaDeAlumnos
{
    public class RespuestaBusquedaDeAlumno
    {
        public int AlumnoId { get; set; }

        public string AlumnoName { get; set; }

        public string Mail { get; set; }

        public int YearDeInicio { get; set; }

        public int? YearDeGraduacion { get; set; }

        public decimal Promedio { get; set; }

    }
}
