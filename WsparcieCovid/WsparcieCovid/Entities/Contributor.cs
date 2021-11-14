using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WsparcieCovid.Entities
{
    public class Contributor
    {
        [Key] public int Id { get; set; }
        [ForeignKey("UserId")] public User User { get; set; }
        
        public ICollection<Donation> Donations { get; set; }
        
        public ICollection<GiftCard> GiftCards { get; set; }
        
        public ICollection<Order> Orders { get; set; }
        
        public ICollection<Review> Reviews { get; set; }
        
        public Address Address { get; set; }
    }
}