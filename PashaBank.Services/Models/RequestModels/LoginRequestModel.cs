using System.ComponentModel.DataAnnotations;

namespace PashaBank.Services.Models.RequestModels
{
    public class LoginRequestModel
    {
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
