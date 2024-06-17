using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.API.Models
{
    [Table("QuestionResponse", Schema = "GSS")]
    public partial class QuestionResponse
    {
        [Key]
        public int QuestionResponseId { get; set; }
        public int QuestionId { get; set; }
        public int ResponseId { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdated { get; set; }
        public int LastUpdatedBy { get; set; }

        [ForeignKey(nameof(QuestionId))]
        [InverseProperty("QuestionResponse")]
        public virtual Question Question { get; set; }
        [ForeignKey(nameof(ResponseId))]
        [InverseProperty("QuestionResponse")]
        public virtual Response Response { get; set; }
    }
}
