using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace first2.Models
{
    public class Book
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        
        
        [ForeignKey("author")]
        [Required]
        public int author_id { get; set; }


        [ForeignKey("category")]
        public int category_id { get; set; }
        public int stock {  get; set; }

        [Column(TypeName = "money")]
        public decimal price { get; set; }
        [Column(TypeName = "date")]
        public DateOnly date { get; set; }

        public virtual Author author { get; set; }
        public virtual Category category { get; set; }

    }
}
