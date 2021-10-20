using System;
using System.ComponentModel.DataAnnotations;

namespace WsparcieCovid.Entities
{
    public class RefreshToken
    {
        [Key] public int Id { get; set; }
        [Required] [MaxLength(600)] public string Token { get; set; }
        [Required] public DateTime ValidTill { get; set; }
    }
}