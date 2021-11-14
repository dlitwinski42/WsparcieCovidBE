using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WsparcieCovid.Entities
{
    public class Product
    {
        [Key] public int Id { get; set; }
        
        [Required] public string Name { get; set; }
        
        [Required] public float Price { get; set; }
        
        [Required] public string Description { get; set; }

        [ForeignKey("EntrepreneurId")] public Entrepreneur Entrepreneur { get; set; }
        
        public ICollection<OrderProducts> OrderProducts { get; set; }
    }

    
}