using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProstateBioBank.Domain
{
    public class Biopsy : Entity
    {
        public virtual string Id { get; set; }

        [Required]
        public virtual Patient Patient { get; set; }

        public ICollection<Alequot> Alequots { get; set; }
    }
}