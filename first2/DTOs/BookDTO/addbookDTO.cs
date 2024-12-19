using first2.Models;
using System.ComponentModel.DataAnnotations;

namespace first2.DTOs.BookDTO
{
    public class addbookDTO
    {
        //public int id { get; set; }
        [Required]
        public string title { get; set; }
        public string description { get; set; }
        public int author { get; set; }
        public int category { get; set; }
        public int stock { get; set; }
        public decimal price { get; set; }
        public DateOnly date { get; set; }
    }
}
