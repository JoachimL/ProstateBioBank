using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ProstateBioBank.ServiceModels
{
    public class ProductType
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
