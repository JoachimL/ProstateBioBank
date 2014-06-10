using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProstateBioBank.Models
{
    public class AlequotCreateModel
    {
        public IEnumerable<SelectListItem> Biopsies { get; set; }

        [Required]
        public string BiopsyId { get; set; }

        [Required]
        public string Id { get; set; }
    }
}