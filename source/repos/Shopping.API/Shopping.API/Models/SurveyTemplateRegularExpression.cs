using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.API.Models
{
    [Table("SurveyTemplateRegularExpression", Schema = "GSS")]
    public partial class SurveyTemplateRegularExpression
    {
        [Key]
        public int SurveyTemplateRegularExpressionId { get; set; }
        public int SurveyTemplateId { get; set; }
        public int QuestionId { get; set; }
        public int RegularExpressionId { get; set; }
        [Required]
        [StringLength(500)]
        public string RegularExpressionValidationMessage { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdated { get; set; }
        public int LastUpdatedBy { get; set; }

        [ForeignKey(nameof(QuestionId))]
        [InverseProperty("SurveyTemplateRegularExpression")]
        public virtual Question Question { get; set; }
        [ForeignKey(nameof(RegularExpressionId))]
        [InverseProperty("SurveyTemplateRegularExpression")]
        public virtual RegularExpression RegularExpression { get; set; }
        [ForeignKey(nameof(SurveyTemplateId))]
        [InverseProperty("SurveyTemplateRegularExpression")]
        public virtual SurveyTemplate SurveyTemplate { get; set; }
    }
}
