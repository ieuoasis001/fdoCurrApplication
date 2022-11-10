using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fdoCurrApp.Models
{
    [Table("currElecStuCount")]
    public class CurrElecStuCount
    {
        [Key]
        public int Id { get; set; }
        public int f { get; set; }
        public int fdo { get; set; }
        public string faculty { get; set; }
        public string department { get; set; }
        public string currCode { get; set; }
        public string isPOOL { get; set; }
        public int semester { get; set; }
        public string uniCode { get; set; }
        public int stuCount { get; set; }
        public int overallCount { get; set; }
        public int isSFL { get; set; }

        //public int class { get; set; }

    }
}
