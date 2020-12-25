using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entity
{
    public class Product : IAggregateRoot
    {
        public Product()
        {
            InvoiceDetail = new HashSet<InvoiceDetail>();
            ImageProduct = new HashSet<ImageProduct>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string productName { get; set; }
        public int catelogID { get; set; }
        public Nullable<int> amount { get; set; }
        public decimal price { get; set; }
        public decimal? priceSale { get; set; }
        public Nullable<int> sale { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime createdDate { get; set; }
        public string? imgLink { get; set; }
        public string productDetail { get; set; }
        public string? status { get; set; }

        [ForeignKey("catelogID")]
        public virtual Catelog Catelog { get; set; }
        public virtual ProductAvatar  ProductAvatar { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetail { get; set; }
        public virtual ICollection<ImageProduct> ImageProduct { get; set; }
    }
}