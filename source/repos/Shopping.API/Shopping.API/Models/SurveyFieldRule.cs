using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.API.Models
{
    [Table("SurveyFieldRule", Schema = "GSS")]
    public partial class SurveyFieldRule
    {
        public SurveyFieldRule()
        {
            SurveyFieldRuleAction = new HashSet<SurveyFieldRuleAction>();
            SurveyFieldRuleCondition = new HashSet<SurveyFieldRuleCondition>();
        }

        [Key]
        public int SurveyFieldRuleId { get; set; }
        public int SurveyId { get; set; }
        [Required]
        [Column("Rule_Name")]
        [StringLength(50)]
        public string RuleName { get; set; }
        [Required]
        [StringLength(10)]
        public string LogicalOperator { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdated { get; set; }
        public int LastUpdatedBy { get; set; }

        [ForeignKey(nameof(SurveyId))]
        [InverseProperty("SurveyFieldRule")]
        public virtual Survey Survey { get; set; }
        [InverseProperty("SurveyFieldRule")]
        public virtual ICollection<SurveyFieldRuleAction> SurveyFieldRuleAction { get; set; }
        [InverseProperty("SurveyFieldRule")]
        public virtual ICollection<SurveyFieldRuleCondition> SurveyFieldRuleCondition { get; set; }
    }
}
