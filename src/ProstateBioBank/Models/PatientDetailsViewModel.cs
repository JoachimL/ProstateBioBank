using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProstateBioBank.Domain;

namespace ProstateBioBank.Models
{
    public class PatientDetailsViewModel
    {
        public string PatientId { get; set; }
        public IEnumerable<Biopsy> Biopsies { get; set; }

        public virtual string Tnm { get; set; }
        public virtual string Ptnm { get; set; }
        public virtual double Psa { get; set; }
        public virtual int GleasonScore { get; set; }
        public virtual DAmicoScore DAmicoScore { get; set; }
        public virtual int YearOfBirth { get; set; }
        public virtual DateTime DateOfSurgery { get; set; }
    }
}