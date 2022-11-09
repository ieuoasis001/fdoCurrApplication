﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fdoCurrApp.Models
{
    [Table("curr")]
    public class Curr
    {
        [Key]
        public int Id { get; set; }
        public int f { get; set; }
        public int fdo { get; set; }
        public string faculty { get; set; }
        public string department { get; set; }
        public string currCode { get; set; }
        public int semester { get; set; }
        public string uniCode { get; set; }
        public string courseName { get; set; }
        public int ects { get; set; }
        public int credit { get; set; }

        //public int class { get; set; }

}
}
