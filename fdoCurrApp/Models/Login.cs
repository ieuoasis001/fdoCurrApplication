using System;
using System.ComponentModel.DataAnnotations;
namespace fdoCurrApp.Models
{
    public class Login
    {
        [Required]
        public int lec_id { get; set; }
        [Required]
        [StringLength(32)]
        public string lec_pass { get; set; }
    }
}
