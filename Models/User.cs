using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        [Required]
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public int win { get; set; }
        public int lose { get; set; }
    }
}