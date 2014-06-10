using ProstateBioBank.Core;
using System;
using System.Collections.Generic;

namespace ProstateBioBank.Domain
{
    public class Patient : Entity
    {
        public virtual string Id { get; set; }
        public virtual string Tnm { get; set; }
        public virtual string Ptnm { get; set; }
        public virtual double Psa { get; set; }
        public virtual int GleasonScore { get; set; }
        public virtual DAmicoScore DAmicoScore { get; set; }
        public virtual int YearOfBirth { get; set; }
        public virtual DateTime DateOfSurgery { get; set; }
        public virtual ICollection<Biopsy> Biopsies { get; set; }
    }
}