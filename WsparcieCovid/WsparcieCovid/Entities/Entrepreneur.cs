using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WsparcieCovid.Entities
{
    public class Entrepreneur
    {
        [Key] public int Id { get; set; }
        
        [Required] [MaxLength(100)] public string Name { get; set; }
        
        [Required] [MaxLength(200)] public string Description { get; set; }

        [Required] [MaxLength(10)] public string NipNumber { get; set; }
        
        [Required] [MaxLength(100)] public string BankAccountNumber { get; set; }
        
        [Required] [MaxLength(100)] public string PhoneNumber { get; set; }
        
        [ForeignKey("UserId")] public User User { get; set; }
        
        public ICollection<Donation> Donations { get; set; }
        
        public ICollection<GiftCard> GiftCards { get; set; }
        
        public ICollection<Review> Reviews { get; set; }
        
        public ICollection<Product> Products { get; set; }
        
        public SupportMethods SupportMethods { get; set; }
        
        public Address Address { get; set; }
    }
    
}