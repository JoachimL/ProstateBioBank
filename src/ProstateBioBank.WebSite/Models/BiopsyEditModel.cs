using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
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