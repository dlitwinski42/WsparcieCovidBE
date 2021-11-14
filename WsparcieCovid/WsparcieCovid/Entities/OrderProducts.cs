using System.ComponentModel.DataAnnotations;

namespace WsparcieCovid.Entities
{
    public class OrderProducts
    {
        [Key] public int Id { get; set; }
        
        [Required] public int ProductId { get; set; }
        
        [Required] public int OrderId { get; set; }
        
        [Required] public Order Order { get; set; }
        
        [Required] public Product Product { get; set; }
        
    }
}