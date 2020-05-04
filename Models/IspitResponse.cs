using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityApp.Models
{
    public class IspitResponse
    {
        public int ispitId { get; set; }
        public string brIndeksa { get; set; }
        public string nazivPredmeta { get; set; }
        public int ocena { get; set; }
        public DateTime datumPolaganja { get; set; }

        public IspitResponse() { }
        public IspitResponse(Ispit ispit)
        {
            this.ispitId = ispit.ispitId;
            this.ocena = ispit.ocena;
            this.datumPolaganja = ispit.datumPolaganja;
            this.brIndeksa = ispit.student.brIndeksa;
            this.nazivPredmeta = ispit.predmet.naziv;
        }
    
    }
}