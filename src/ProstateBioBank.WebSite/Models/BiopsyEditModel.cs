using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProstateBioBank.Models
{
    public class BiopsyEditModel
    {
        public IEnumerable<SelectListItem> Patients { get; set; }

        [Required]
        public string PatientId { get; set; }

        [Required]
        public string Id { get; set; }
    }
}