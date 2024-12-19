using first2.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace first2.DTOs.BookDTO
{
    public class ShowBookDTO
    {
        public int id {  get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string author { get; set; }
        public string category { get; set; }
        public int stock { get; set; }
        public decimal price { get; set; }
        public DateOnly date { get; set; }
    }
}
