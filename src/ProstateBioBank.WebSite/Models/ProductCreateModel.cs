using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProstateBioBank.Models
{
    public class ProductCreateModel
    {
        public IEnumerable<SelectListItem> AvailableAlequots { get; set; }
        public IEnumerable<SelectListItem> AvailableProductTypes { get; set; }
        public string AlequotId { get; set; }
        public int ProductTypeId { get; set; }
        public string Location { get; set; }
        public DateTime Created { get; set; }
    }
}