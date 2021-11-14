using System.ComponentModel.DataAnnotations;

namespace WsparcieCovid.DTO
{
    public class OrderDto
    {
        [Required(ErrorMessage = "Contributor Id is required")]
        public int ContributorId { get; set; }
        
        [Required(ErrorMessage = "Entrepreneur Id is required")]
        public int EntrepreneurId { get; set; }
        
        public string OrderComments { get; set; }
    }
}