using System;
using System.ComponentModel.DataAnnotations;

namespace ProstateBioBank.Domain
{
    public class Product : Entity
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual Alequot Alequot { get; set; }

        [Required]
        public virtual ProductType ProductType { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public string Location { get; set; }
    }
}