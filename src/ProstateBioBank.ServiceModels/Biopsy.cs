using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProstateBioBank.ServiceModels
{
    public class Biopsy
    {
        public string Id { get; set; }

        [Required]
        public string PatientId { get; set; }

        public ICollection<Alequot> Alequots { get; set; }
    }
}
