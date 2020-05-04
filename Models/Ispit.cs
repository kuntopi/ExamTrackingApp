using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UniversityApp.Models
{
    public class Ispit
    {
        [Key]
        public int ispitId { get; set; }
        [Required]
        public int studentId { get; set; }
        [Required]
        public int predmetId { get; set; }
        [Required]
        [Range(5, 10)]
        public int ocena { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy HH:mm:ss}",
            ApplyFormatInEditMode = true)]
        public DateTime datumPolaganja { get; set; }

        //[ForeignKey]
        public Predmet predmet { get; set; }
        //[ForeignKey("brIndeksa")]
        public Student student { get; set; }

        public ICollection<Ispit> ispiti { get; set; }
    }
}