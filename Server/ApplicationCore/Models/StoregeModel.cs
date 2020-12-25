using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class StoregeModel
    {
        public int id { get; set; }
        public int productID { get; set; }
        public int amount { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime importDate { get; set; }
        public virtual ProductModel Product { get; set; }
    }
}