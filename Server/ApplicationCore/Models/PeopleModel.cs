using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApplicationCore.Models
{
    public class PeopleModel
    {
        public int id { get; set; }
        public string username { get; set; }
        [JsonIgnore]
        public string password { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime birthDate { get; set; }
        public string address { get; set; }
        public int phone { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime registraDate { get; set; }
        public int role_ID { get; set; }
        public string status { get; set; }
        public virtual RoleModel Role { get; set; }
    }
}