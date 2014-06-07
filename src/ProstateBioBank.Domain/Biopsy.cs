using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProstateBioBank.Domain
{
    public class Biopsy
    {
        public virtual string Id { get; set; }

        [Required]
        public virtual Patient Patient { get; set; }

        public ICollection<Alequot> Alequots { get; set; }
    }
}