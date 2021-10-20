using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WsparcieCovid.Entities
{
    public class Product
    {
        [Key] public int Id { get; set; }
        
        [Required] public float Price { get; set; }
        
        [Required] public string Description { get; set; }
        
        [Required] public string OrderComment { get; set; }

        [Required] public string ReturnMsg { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(20)")]
        
        public OrderStatus Status { get; set; }
    }

    
}