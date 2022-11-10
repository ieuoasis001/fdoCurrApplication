using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fdoCurrApp.Models
{
    [Table("school")]
    public class School
    {
        [Key]
        public int id { get; set; }
        public string faculty { get; set; }
    }
}
