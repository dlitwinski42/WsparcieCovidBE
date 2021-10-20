using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WsparcieCovid.Entities
{
    public class Address
    {
        [Key] public int Id { get; set; }
        
        [Required] public string City { get; set; }
        
        [Required] public string Street { get; set; }
        
        [Required] public string HouseNumber { get; set; }
        
        [Required] public string FlatNumber { get; set; }
        
        [ForeignKey("ContributorId")] public Contributor Contributor { get; set; }
        
        [ForeignKey("EntrepreneurId")] public Entrepreneur Entrepreneur { get; set; }
    }
}