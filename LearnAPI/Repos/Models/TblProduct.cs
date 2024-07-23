using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnAPI.Repos.Models
{
    [Table("tbl_product")]
    public class TblProduct
    {
        [Key]
        public string Code { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
