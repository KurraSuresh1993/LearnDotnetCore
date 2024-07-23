using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnAPI.Repos.Models
{
    [Table("tbl_productimage")]
    public class TblProductImage
    {
        [Key]
        public int Id {  get; set; }

        public string? ProductCode {  get; set; }

        [Column("ProductImage",TypeName ="image")]
        public byte[]? ProductImage { get; set; }
    }
}
