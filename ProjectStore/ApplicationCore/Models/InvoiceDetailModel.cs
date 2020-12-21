using System;

namespace ApplicationCore.Models
{
    public class InvoiceDetailModel
    {
        public int id { get; set; }
        public int invoiceID { get; set; }
        public Nullable<int> productID { get; set; }
        public Nullable<int> comboID { get; set; }
        public int amount { get; set; }
        public decimal price { get; set; }

        public virtual InvoiceModel Invoice { get; set; }
        public virtual ComnoModel Combo { get; set; }
        public virtual ProductModel Product { get; set; }
    }
}