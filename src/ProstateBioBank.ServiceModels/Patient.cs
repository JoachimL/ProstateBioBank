﻿using ProstateBioBank.Core;
using System;
using System.Collections.Generic;

namespace ProstateBioBank.ServiceModels
{
    public class Patient
    {
        public string Id { get; set; }
        public string Tnm { get; set; }
        public string Ptnm { get; set; }
        public double Psa { get; set; }
        public int GleasonScore { get; set; }
        public DAmicoScore DAmicoScore { get; set; }
        public int YearOfBirth { get; set; }
        public DateTime DateOfSurgery { get; set; }
        public ICollection<Biopsy> Biopsies { get; set; }
    }
}
