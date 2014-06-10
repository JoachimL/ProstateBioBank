using System;

namespace ProstateBioBank.Models
{
    public class ProductIndexViewModel
    {
        public string PatientId { get; set; }
        public string BiopsyId { get; set; }
        public string AlequotId { get; set; }
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Location { get; set; }
    }
}