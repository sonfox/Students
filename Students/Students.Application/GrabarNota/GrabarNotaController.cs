using Students.Domain.Entities.GrabarNota;
using Students.Persistence.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
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
        private void Promedio(ParametrosNotaAGrabar nota, StudentsDBEntities db)
        {
            if (nota.TipoDeExamen == 3 )
            {
                var consulta = from bas in db.StudentsAverageByYear
                               join s in db.Students on bas.StudentId equals s.Id
                               where bas.Year == nota.FechaActual.Year
                               select bas;
                if (consulta != null)
                {
                    StudentsAverageByYear cont = (from aby in db.StudentsAverageByYear
                                                   join s in db.Students on aby.StudentId equals s.Id
                                                   where aby.Year == nota.FechaActual.Year
                                                   select aby).First();
                    cont.GradeQuantity = (short)(cont.GradeQuantity + 1);
                    cont.Average = (cont.Average + nota.Nota) / (2 );
                    db.SaveChanges();


                }



                if (consulta == null)
                {
                    var FilaDB = db.StudentsAverageByYear.Create();
                    FilaDB.Year = (short)nota.FechaActual.Year;
                    FilaDB.Average = nota.Nota;
                    FilaDB.GradeQuantity = 1;
                    FilaDB.StudentId = nota.AlumnoId;
                    db.StudentsAverageByYear.Add(FilaDB);
                    db.SaveChanges();

                    int IDaby = FilaDB.Id;

                }
                var con = (from dat in db.Students
                           join s in db.Grades on dat.Id equals s.StudentId
                           where s.GradeType == 3 
                           select dat).First();
                con.Average = (con.Average + nota.Nota) /2;
                db.SaveChanges();

                

                

            }

            
            


        }

        private void ProXMateriaXAño(ParametrosNotaAGrabar nota, StudentsDBEntities db)
        {
            if (nota.TipoDeExamen == 3)
            {
                var consul = (from dl in db.SubjectsAverageByYear
                             join ff in db.Subjects on dl.SubjectId equals ff.Id
                             where dl.Year == nota.FechaActual.Year
                             select dl).First();
                if (consul != null)
                {
                    consul.GradeQuantity = ((short)(consul.GradeQuantity + 1));
                     consul.Average  = (consul.Average+ nota.Nota) /2;
                    db.SaveChanges() ;

                }
                if (consul == null)
                {
                    var fdb = db.SubjectsAverageByYear.Create();
                    fdb.Year = (short)nota.FechaActual.Year;
                    fdb.Average = nota.Nota;
                    fdb.GradeQuantity = 1;
                    fdb.SubjectId = nota.MateriaId;
                    db.SubjectsAverageByYear.Add(fdb);
                    db.SaveChanges() ;

                }




            }



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
            if(nota.MateriaId != 0)
            {
                var con = from c in db.Subjects
                          where c.Id == nota.MateriaId
                          select c;
                if (con == null)
                    throw new Exception("el id de la materia no existe");
               
            }

            if (nota.AlumnoId != 0)
            {
                var j = from c in db.Students
                        where c.Id == nota.AlumnoId
                        select c;
                if (j == null) throw new Exception("el id del alumno no existe");
            }

        }
    }
}
