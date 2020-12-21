using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entity
{
    public class Combo : IAggregateRoot
    {
        public Combo()
        {
            InvoiceDetail = new HashSet<InvoiceDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string comboName { get; set; }
        public string productList { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime startDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime endDate { get; set; }
        public decimal price { get; set; }
        public decimal priceSale { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetail { get; set; } 
    }
}