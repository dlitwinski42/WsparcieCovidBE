using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WsparcieCovid.Entities
{
    public class Order
    {
        [Key] public int Id { get; set; }
        
        [ForeignKey("ContributorId")] public Contributor Contributor { get; set; }
        
        [ForeignKey("EntrepreneurId")] public Entrepreneur Entrepreneur { get; set; }
        
        [ForeignKey("ProductId")] public Product Product { get; set; }
    }
    
    public enum OrderStatus
    {
        Ordered, Paid, Recieved
    }
}