using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProstateBioBank.Domain
{
    public class ProductType
    {
        public virtual long Id { get; set; }

        [Required]
        public virtual string Name { get; set; }
    }
}