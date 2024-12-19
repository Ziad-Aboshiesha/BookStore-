using System.ComponentModel.DataAnnotations;

namespace first2.DTOs.CustomerDTO
{
    public class EditCustomerDTO
    {
        [Required]
        public string CustomerId { get; set; }
        public string? address { get; set; }

        //[Required, RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "weak password")]
        //public string password { get; set; } 
        public string? phone { get; set; }
        [Required, MaxLength(50)]
        public string CustomerName { get; set; }
    }
}
