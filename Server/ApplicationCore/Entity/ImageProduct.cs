using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Entity
{
    public class ImageProduct : IAggregateRoot
    {
        public ImageProduct()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string image { get; set; }
        [ForeignKey("Product")]
        public int productID { get; set; }
        public virtual Product Product { get; set; }
    }
}