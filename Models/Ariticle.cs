using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace asp14_Validation.Models
{
    
    [Table("posts")]
    public class Article
    {
        [Key]
        public int ID { get; set; }
        [StringLength(255, MinimumLength = 5, ErrorMessage = "{0} phải dài từ {1} tới {2}")]
        [Required(ErrorMessage = "{0} phải nhập")]
        [Column(TypeName = "nvarchar")]
        [DisplayName("Tiêu đề")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [DisplayName("Ngày tạo")]
        public DateTime Created { get; set; }
        [Column(TypeName = "ntext")]
        [DisplayName("Nội dung")]
        public string Content {set; get;}
    }
}