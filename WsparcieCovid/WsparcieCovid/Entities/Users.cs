using System.ComponentModel.DataAnnotations;

namespace WsparcieCovid.Entities
{
    public class User
    {
        [Key] public int Id { get; set; }
        [Required] [MaxLength(50)] public string Username { get; set; }
        [Required] [MaxLength(400)] public string PassHash { get; set; }
        
        [Required] [MaxLength(50)] public string FirstName { get; set; }
        
        [Required] [MaxLength(50)] public string LastName { get; set; }
        
        [Required] [MaxLength(100)] public string Email { get; set; }
        
        public Contributor Contributor { get; set; }
        
        public Entrepreneur Entrepreneur { get; set; }
        
    }
}