using System;
using System.ComponentModel.DataAnnotations;

namespace ProstateBioBank.Domain
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
