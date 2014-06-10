using System.ComponentModel.DataAnnotations;

namespace ProstateBioBank.Domain
{
    public class ProductType : Entity
    {
        public virtual long Id { get; set; }

        [Required]
        public virtual string Name { get; set; }
    }
}