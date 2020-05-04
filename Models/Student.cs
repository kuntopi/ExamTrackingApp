using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Models
{
    public class Student
    {
        [Key]
        public int studentId { get; set; }
        [Required]
        public string brIndeksa { get; set; }
        [Required]
        public string ime { get; set; }
        [Required]
        public string prezime { get; set; }
        public string grad { get; set; }

        public ICollection<Student> studenti { get; set; }

    }
    public class UniversityDBContext : DbContext
    {
        public UniversityDBContext()
        { }
        public DbSet<Student> Students { get; set; }

        public System.Data.Entity.DbSet<UniversityApp.Models.Ispit> Ispits { get; set; }

        public System.Data.Entity.DbSet<UniversityApp.Models.Predmet> Predmets { get; set; }
    }
}