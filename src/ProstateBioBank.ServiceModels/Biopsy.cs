using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
