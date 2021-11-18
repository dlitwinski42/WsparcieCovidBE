using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WsparcieCovid.Entities
{
    public class Donation
    {
        [Key] public int Id { get; set; }
        
        [ForeignKey("ContributorId")] public Contributor Contributor { get; set; }
        
        [ForeignKey("EntrepreneurId")] public Entrepreneur Entrepreneur { get; set; }
        
        [Required] public float Amount { get; set; }
        
        public DateTime DateSent { get; set; }
        
        public DateTime DateConfirmed { get; set; }
        
        public string DonationCode { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(20)")]
        public DonationStatus Status { get; set; }
    }

    public enum DonationStatus
    {
        Created, Sent, Confirmed
    }
}