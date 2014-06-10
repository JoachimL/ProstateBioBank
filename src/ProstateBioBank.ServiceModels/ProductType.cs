using System.ComponentModel.DataAnnotations;

namespace ProstateBioBank.ServiceModels
{
    public class ProductType
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
