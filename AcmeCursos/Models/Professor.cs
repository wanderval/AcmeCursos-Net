using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AcmeCursos.Models
{
    [Table("Professor")]
    public class Professor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 3)]
        [Display(Name="Nome")]
        public string Nome { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 3)]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 3)]
        [Display(Name = "Titulação")]
        public string Titulacao { get; set; }




    }
}