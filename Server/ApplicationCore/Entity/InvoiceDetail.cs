using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entity
{
    public class InvoiceDetail : IAggregateRoot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("Invoice")]
        public int invoiceID { get; set; }
        [ForeignKey("Product")]
        public Nullable<int> productID { get; set; }
        [ForeignKey("Combo")]
        public Nullable<int> comboID { get; set; }
        public int amount { get; set; }
        public decimal price { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Combo Combo { get; set; }
        public virtual Product Product { get; set; }
    }
}