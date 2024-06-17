using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.API.Models
{
    [Table("QuestionType", Schema = "GSS")]
    public partial class QuestionType
    {
        public QuestionType()
        {
            Question = new HashSet<Question>();
        }

        [Key]
        public int QuestionTypeId { get; set; }
        [Required]
        [StringLength(100)]
        public string QuestionTypeName { get; set; }
        [Required]
        [StringLength(5)]
        public string QuestionTypeCode { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdated { get; set; }
        public int LastUpdatedBy { get; set; }

        [InverseProperty("QuestionType")]
        public virtual ICollection<Question> Question { get; set; }
    }
}
