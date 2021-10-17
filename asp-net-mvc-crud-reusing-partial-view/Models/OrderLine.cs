using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace asp_net_mvc_crud_reusing_partial_view.Models
{
    public class OrderLine
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Order #")]
        public int OrderID { get; set; }

        [Required]
        [Display(Name = "Product")]
        public int ProductID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [NotMapped]
        [Display(Name = "Sub Total")]
        public decimal? SubTotal { get { return Product.Price * Quantity; } set { } }

        [ForeignKey("OrderID")]
        public Order Order { get; set; }

        [ForeignKey("ProductID")]
        public Product Product { get; set; }
    }
}