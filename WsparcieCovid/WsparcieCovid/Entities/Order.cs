using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WsparcieCovid.Entities
{
    public class Order
    {
        [Key] public int Id { get; set; }
        
        public DateTime DateOrdered { get; set; }
        
        public DateTime DatePaid { get; set; }
        
        public DateTime DateReceived { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(20)")]
        public OrderStatus Status { get; set; }
        [ForeignKey("ContributorId")] public Contributor Contributor { get; set; }
        
        [ForeignKey("EntrepreneurId")] public Entrepreneur Entrepreneur { get; set; }
        
        public ICollection<OrderProducts> OrderProducts { get; set; }
    }
    
    public enum OrderStatus
    {
        Ordered, Paid, Received
    }
}