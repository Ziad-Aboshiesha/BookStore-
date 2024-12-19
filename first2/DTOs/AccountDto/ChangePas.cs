using System.ComponentModel.DataAnnotations;

namespace first2.DTOs.AdminDTO
{
    public class ChangePas
    {
        //[Required]
        //public string id { get; set; }
        [Required]
        public string oldpass { get; set; }
        [Required]
        public string newpass { get; set; }
        [Required, Compare("newpass", ErrorMessage = "password dont match")]
        public string confirm_newpass { get; set; }


    }
}
