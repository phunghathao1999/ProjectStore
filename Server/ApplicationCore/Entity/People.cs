using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entity
{
    public class People : IAggregateRoot
    {
        public People()
        {
            InvoiceCustomer = new HashSet<Invoice>();
            InvoiceShipper = new HashSet<Invoice>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime birthDate { get; set; }
        public string address { get; set; }
        public int phone { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime registraDate { get; set; }
        [ForeignKey("Role")]
        public int role_ID { get; set; }
        public string? status { get; set; }
        public virtual Role Role { get; set; }
        [InverseProperty(nameof(Invoice.Customer))]
        public virtual ICollection<Invoice> InvoiceCustomer { get; set; }
        [InverseProperty(nameof(Invoice.Shipper))]
        public virtual ICollection<Invoice> InvoiceShipper { get; set; } 
    }
}