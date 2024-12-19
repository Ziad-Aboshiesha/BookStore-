using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace first2.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [ForeignKey("customer")]
        public string customer_id { get; set; }
        [Column(TypeName = "date")]
        public DateOnly date { get; set; }
        public string status { get; set; }

        public virtual Customer customer { get; set; }

        public virtual List<Order_details> order_details { get; set; } = new List<Order_details>();
    }
}
