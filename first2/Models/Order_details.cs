using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace first2.Models
{
    public class Order_details
    {
        [Key, Column(Order = 0)]

        public int order_id {  get; set; }
        [Key, Column(Order =1)]
        public int book_id { get; set; }

        [Column(TypeName ="money")]
        public decimal unit_price { get; set; }

        public int quantity { get; set; }

        public virtual Order order { get; set; } 
        public virtual Book book { get; set; }


    }
}
