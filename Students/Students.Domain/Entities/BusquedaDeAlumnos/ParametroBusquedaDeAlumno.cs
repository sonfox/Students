﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.Entities.BusquedaDeAlumnos
{
    public class ParametroBusquedaDeAlumno
    {
        public string Alumno { get; set; }

        public bool? EstaGraduado { get; set; }

        public int? YearDeGraduciaon { get; set; }

        public DateTime? YearDeInicio { get; set; }

        public decimal? Promedio { get; set; }

        public string Mail { get; set; }

    }
}
