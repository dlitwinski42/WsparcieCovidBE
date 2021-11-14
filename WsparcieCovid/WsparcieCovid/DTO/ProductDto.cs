using System.ComponentModel.DataAnnotations;

namespace WsparcieCovid.DTO
{
    public class ProductDto
    { 
        [Required(ErrorMessage = "Entrepreneur Id is required")]
        public int EntrepreneurId { get; set; } 
        
        [Required(ErrorMessage = "Price is required")]
        public float Price { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        
    }
}