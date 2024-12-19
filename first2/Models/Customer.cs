using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace first2.Models
{
    public class Customer : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string name { get; set; }

        public string? address { get; set; }

        public virtual List<Order> Orders { get; set; }=new List<Order>();
    }
}
