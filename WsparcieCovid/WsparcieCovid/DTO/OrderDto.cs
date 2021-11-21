using System.ComponentModel.DataAnnotations;

namespace WsparcieCovid.DTO
{
    public class OrderDto
    {
        [Required(ErrorMessage = "Contributor Id is required")]
        public int ContributorId { get; set; }
        
        [Required(ErrorMessage = "Entrepreneur Id is required")]
        public int EntrepreneurId { get; set; }
        
        public string City { get; set; }
        
        public string Street { get; set; }
        
        public string HouseNumber { get; set; }
        
        public string flatNumber { get; set; }
        
        public string OrderComments { get; set; }
    }
}