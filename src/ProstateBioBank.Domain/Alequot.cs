using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProstateBioBank.Domain
{
    public class Alequot : Entity
    {
        public virtual string Id { get; set; }

        [Required]
        public virtual Biopsy Biopsy { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}