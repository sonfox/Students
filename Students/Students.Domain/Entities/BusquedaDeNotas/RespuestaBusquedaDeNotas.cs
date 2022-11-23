using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.BusquedaDeNotas
{
    internal class RespuestaBusquedaDeNotas
    {

        public int NotaId { get; set; }

        public  string Materia { get; set; }

        public int Nota { get; set; }

        public DateTime Fecha { get; set; }

        public int TipoNota { get; set; }
    }
}
