using System;
using System.ComponentModel.DataAnnotations;

namespace ProstateBioBank.ServiceModels
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string AlequotId { get; set; }

        [Required]
        public int ProductTypeId { get; set; }

        public string BiopsyId { get; set; }

        public string PatientId { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public string Location { get; set; }
    }
}
