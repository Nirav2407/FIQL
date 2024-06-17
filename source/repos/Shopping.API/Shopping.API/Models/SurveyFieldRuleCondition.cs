using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.API.Models
{
    [Table("SurveyFieldRuleCondition", Schema = "GSS")]
    public partial class SurveyFieldRuleCondition
    {
        [Key]
        public int SurveyFieldRuleConditionId { get; set; }
        public int SurveyFieldRuleId { get; set; }
        public int QuestionId { get; set; }
        [Required]
        [StringLength(10)]
        public string ComparisonOperator { get; set; }
        [Required]
        public string Value { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdated { get; set; }
        public int LastUpdatedBy { get; set; }

        [ForeignKey(nameof(SurveyFieldRuleId))]
        [InverseProperty("SurveyFieldRuleCondition")]
        public virtual SurveyFieldRule SurveyFieldRule { get; set; }
    }
}
