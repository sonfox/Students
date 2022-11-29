using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.Entities.GrabarNota
{
    public class ParametrosNotaAGrabar
    {
        public int AlumnoId { get; set; }

        

        public int MateriaId { get; set;}

        public Byte Nota { get; set;}

        public DateTime FDExamen { get; set; }

        public Byte TipoDeExamen { get; set; }




    }
}
