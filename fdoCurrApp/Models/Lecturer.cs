using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fdoCurrApp.Models
{
    [Table("lecturerInfo")]
    public class Lecturer
    {
        [Key]
        public int lec_id { get; set; }
        public string lec_pass { get; set; }

        public int fdo_id { get; set; }
        public string lec_name { get; set; }
        public string lec_surname { get; set; }
        public string auth_key { get; set; }
        public int time { get; set; }
    }
}
