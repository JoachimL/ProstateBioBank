using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ProstateBioBank.ServiceModels
{
    public class Entity
    {
        public Entity()
        {
            Added = DateTime.Now;
        }

        [Required]
        public DateTime Added { get; set; }
    }
}
