//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Students.Persistence.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Grades
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public System.DateTime GradeDate { get; set; }
        public byte GradeNumber { get; set; }
        public byte GradeType { get; set; }
    
        public virtual Subjects Subjects { get; set; }
        public virtual Students Students { get; set; }
    }
}
