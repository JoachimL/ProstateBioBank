using System.Collections.Generic;

namespace ProstateBioBank.ServiceModels
{
    public class Alequot
    {
        public string Id { get; set; }

        public string BiopsyId { get; set; }

        public string PatientId { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
