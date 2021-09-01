using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeneralStoreAPI.Models
{
    public class Transaction
    {
        // (Assumed by entity framework) [Key]
        public int Id { get; set; }
        [Required]
        // (Asssumed by entity framework) [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [Required]
        public int CustomerId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }

        public DateTime DateOfTransaction { get; set; }
        public int Quantity { get; set; }
    }
}