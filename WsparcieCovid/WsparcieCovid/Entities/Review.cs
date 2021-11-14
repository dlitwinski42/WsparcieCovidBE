using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WsparcieCovid.Entities
{
    public class Review
    {
        [Key] public int Id { get; set; }
        
        [Required] public string ReviewBody { get; set; }
        
        [Required] public int Grade { get; set; }
        
        [Required] public DateTime Timestamp { get; set; }
        
        [ForeignKey("ContributorId")] public Contributor Contributor { get; set; }
        
        [ForeignKey("EntrepreneurId")] public Entrepreneur Entrepreneur { get; set; }

    }
}