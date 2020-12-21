using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class ProductModel
    {
        public int id { get; set; }
        public string productName { get; set; }
        public int catelogID { get; set; }
        public int amount { get; set; }
        public decimal price { get; set; }
        public decimal priceSale { get; set; }
        public Nullable<int> sale { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime createdDate { get; set; }
        public string imgLink { get; set; }
        public string productDetail { get; set; }
        public string status { get; set; }

        public virtual CatelogModel Catelog { get; set; }
    }
}