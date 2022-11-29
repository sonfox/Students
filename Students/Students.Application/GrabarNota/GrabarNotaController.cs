using Students.Domain.Entities.GrabarNota;
using Students.Persistence.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Application.GrabarNota
{
    internal class GrabarNotaController
    {
        public int GrabarNota(ParametrosNotaAGrabar nota)
        {
            var db = new StudentsDBEntities();

            Validar(nota, db);

            var Ebd = db.Grades.Create();
            
            Ebd.StudentId = nota.AlumnoId;
            Ebd.SubjectId = nota.MateriaId;
            Ebd.GradeDate = nota.FDExamen;
            Ebd.GradeNumber = nota.Nota;
            Ebd.GradeType = nota.TipoDeExamen;
            db.Grades.Add(Ebd);
            db.SaveChanges();

            int nId = Ebd.Id;
           return nId;

           


        }

        private void Validar(ParametrosNotaAGrabar nota, StudentsDBEntities db)
        {
            if (nota.Nota >10 || nota.Nota <1)
            {
                throw new NotImplementedException("nota invalida, solo recive del 1 al 10");
            }
            var FechaActual = DateTime.Today;
            if (nota.FDExamen > FechaActual )
            {
                throw new NotImplementedException("fecha erronea");
            }


        }
    }
}
