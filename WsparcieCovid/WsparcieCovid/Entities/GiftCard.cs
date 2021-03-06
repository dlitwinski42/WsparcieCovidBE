using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WsparcieCovid.Entities
{
    public class GiftCard
    {
        [Key] public int Id { get; set; }
        
        [Required] public string RedeemCode { get; set; }
        
        [Required] public float Amount { get; set; }

        public DateTime TimeOrdered;

        public DateTime TimePaid;

        public DateTime TimeUsed;
        [ForeignKey("ContributorId")] public Contributor Contributor { get; set; }
        
        [ForeignKey("EntrepreneurId")] public Entrepreneur Entrepreneur { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(20)")]
        public GiftCardStatus Status { get; set; }
    }

    public enum GiftCardStatus
    {
        Ordered, Paid, Used, Failed
    }
}