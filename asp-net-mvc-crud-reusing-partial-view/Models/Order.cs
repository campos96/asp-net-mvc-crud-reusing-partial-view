using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace asp_net_mvc_crud_reusing_partial_view.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public int CustomerID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [NotMapped]
        public decimal? Amount { get { return OrderLines.Sum(o => o.Product.Price * o.Quantity); } set { } }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }

        public Order()
        {
            this.Amount = 0.00m;
            this.OrderLines = new HashSet<OrderLine>();
        }
    }
}