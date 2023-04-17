using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp14_Validation.Models
{
    [Table("posts")]
    public class Article
    {
        [Key]
        public int ID { get; set; }
        [StringLength(255)]
        [Required]
        [Column(TypeName = "nvarchar")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Created { get; set; }
        [Column(TypeName = "ntext")]
        public string Content {set; get;}
    }
}