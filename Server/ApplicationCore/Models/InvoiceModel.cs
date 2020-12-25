using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class InvoiceModel
    {
        public int id { get; set; }
        public string? customerName { get; set; }
        public int customerID { get; set; }
        public Nullable<int> shipperID { get; set; }
        public decimal totalMoney { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime createdDate { get; set; }
        public Nullable<int> phone { get; set; }
        public string? customerAddesss { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? shipDate { get; set; }
        public string? status { get; set; }
        public string? note { get; set; }

        public virtual PeopleModel Customer { get; set; }
        public virtual PeopleModel Shipper { get; set; }
    }
}