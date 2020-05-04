using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UniversityApp.Models
{
    public class Predmet
    {
        [Key]
        public int predmetId { get; set; }
        [Required]
        public string naziv { get; set; }

        public ICollection<Predmet> predmeti { get; set; }
    }
}