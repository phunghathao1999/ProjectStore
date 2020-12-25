using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class ComnoModel
    {
        public int id { get; set; }
        public string comboName { get; set; }
        public string productList { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime startDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime endDate { get; set; }
        public decimal price { get; set; }
        public decimal priceSale { get; set; }
    }
}