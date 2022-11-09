using System;
using System.ComponentModel.DataAnnotations;
namespace fdoCurrApp.Models
{
    public class Lecturer
    {
        public Login login { get; set; }

        public int fdo_id { get; set; }
        [StringLength(128)]
        public string lec_name { get; set; }
        [StringLength(128)]
        public string lec_surname { get; set; }
        
        [Required]
        [StringLength(32)]
        public int auth_key { get; set; }
        public int time { get; set; }
    }
}
