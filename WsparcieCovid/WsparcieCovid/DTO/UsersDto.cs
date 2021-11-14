using System.ComponentModel.DataAnnotations;

namespace WsparcieCovid.DTO
{
    public class UsersDto
    {
        [Required(ErrorMessage = "Username is required")]
        [MaxLength(50)]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [MaxLength(50)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }
        
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }
        public string NipNumber { get; set; }
        public string BankAccountNumber { get; set; }
        public string PhoneNumber { get; set; }
        
        public string City { get; set; }
        
        public string Street { get; set; }
        
        public string HouseNumber { get; set; }
        
        public string flatNumber { get; set; }
        
        public bool supportDonation { get; set; }

        public bool supportGiftCard { get; set; }
        
        public bool supportOrder { get; set; }

    }
}