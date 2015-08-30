using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AcmeCursos.Models
{
    [Table("Curso")]
    public class Curso
    {

        public int Id { get; set; }

        [Display(Name = "Professor")]
        public string[] ProfessorId { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Nome { get; set; }

        [StringLength(250, MinimumLength = 0)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Date Limite para Inscrição")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataLimiteInscricao { get; set; }

        [UIHint("_CursoProfessores")]
        public virtual ICollection<CursoProfessor> CursoProfessor { get; set; }

       //public virtual Professor Professor { get; set; }
    }
}