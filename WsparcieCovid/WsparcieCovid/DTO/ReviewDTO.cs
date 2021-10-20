using System.ComponentModel.DataAnnotations;

namespace WsparcieCovid.DTO
{
    public class ReviewDTO
    {
        
        [Required(ErrorMessage = "Contributor Id is required")]
        public int ContributorId { get; set; }
        
        [Required(ErrorMessage = "Entrepreneur Id is required")]
        public int EntrepreneurId { get; set; }
        
        [Required(ErrorMessage = "Grade is required")]
        public int Grade { get; set; }

        [Required(ErrorMessage = "Review is required")]
        public string ReviewBody { get; set; }
    }
}