using System.ComponentModel.DataAnnotations;

namespace first2.DTOs.AdminDTO
{
    public class AddAdminDTO
    {

        
        [Required, MaxLength(50)]
        public string user { get; set; }
        [Required, EmailAddress]
        public string EmailAddress { get; set; }
        public string? phone { get; set; }
        [Required, RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "weak password")]
        public string password { get; set; }


    }
}
