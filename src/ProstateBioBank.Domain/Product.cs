using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProstateBioBank.Domain
{
    public class Product
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