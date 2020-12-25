using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Entity
{
    public class ProductAvatar : IAggregateRoot
    {
        public ProductAvatar()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string avatar { get; set; }
        [ForeignKey("product")]
        public int productID { get; set; }

        public virtual Product product { get; set; }
    }
}