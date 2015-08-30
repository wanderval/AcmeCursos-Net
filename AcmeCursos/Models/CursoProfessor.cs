using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AcmeCursos.Models
{
    [Table("CursoProfessor")]
    public class CursoProfessor
    {
        public int Id { get; set; }
        public int professorId { get; set; }
        public int cursoId { get; set; }

        public virtual Professor professor { get; set; }
        public virtual Curso Curso { get; set; }


    }
}