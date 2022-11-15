using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fdoCurrApp.Models
{
    [Table("fdo")]
    public class Fdo
    {
        [Key]
        public int id { get; set; }
        public int f { get; set; }
        public int d { get; set; }
        public int o { get; set; }
        public string name { get; set; }
        public string deptLangName { get; set; }
        public int deptLangCode { get; set; }
    }
}
