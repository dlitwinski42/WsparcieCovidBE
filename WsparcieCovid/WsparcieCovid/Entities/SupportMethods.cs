using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WsparcieCovid.Entities
{
    public class SupportMethods
    {
        [Key] public int Id { get; set; }
        
        [ForeignKey("EntrepreneurId")] public Entrepreneur Entrepreneur { get; set; }
        
        [Required] public bool CanDonate { get; set; }
        
        [Required] public bool CanOrder { get; set; }
        
        [Required] public bool CanGiftCard { get; set; }
    }
}