using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entity
{
    public class Role : IAggregateRoot
    {
        public Role()
        {
            People = new HashSet<People>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string roleName { get; set;}
        public virtual ICollection<People> People { get; set; }
    }
}