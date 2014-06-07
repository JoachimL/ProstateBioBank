using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProstateBioBank.Domain
{
    public class Alequot
    {
        public virtual string Id { get; set; }

        [Required]
        public virtual Biopsy Biopsy { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}