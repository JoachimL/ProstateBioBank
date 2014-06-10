using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProstateBioBank.Models
{
    public class BiopsyCreateModel
    {
        public IEnumerable<SelectListItem> Patients { get; set; }

        [Required]
        public string PatientId { get; set; }

        [Required]
        public string Id { get; set; }
    }
}