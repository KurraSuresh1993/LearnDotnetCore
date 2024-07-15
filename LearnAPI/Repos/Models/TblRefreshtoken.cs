using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnAPI.Repos.Models
{
    [Table("tbl_refreshtoken")]
    public class TblRefreshtoken
    {

        [Key]
        [StringLength(50)]
        public string UserId { get; set; }

    
        [StringLength(50)]
        public string TokenId {  get; set; }

       
        public string RefreshToken { get; set; }
    }
}
