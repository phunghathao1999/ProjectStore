using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entity
{
    public class Invoice : IAggregateRoot
    {
        public Invoice()
        {
            InvoiceDetail = new HashSet<InvoiceDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? customerName { get; set; }
        [ForeignKey(nameof(Customer)), Column(Order = 0)]
        public int customerID { get; set; }
        [ForeignKey(nameof(Shipper)), Column(Order = 0)]
        public Nullable<int> shipperID { get; set; }
        public decimal totalMoney { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime createdDate { get; set; }
        public Nullable<int> phone { get; set; }
        public string? customerAddesss { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? shipDate { get; set; }
        public string? status { get; set; }
        public string? note { get; set; }
        public virtual People Customer { get; set; }
        public virtual People Shipper { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetail { get; set; }
    }
}