using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.API.Models
{
    [Table("SurveyTemplate", Schema = "GSS")]
    public partial class SurveyTemplate
    {
        public SurveyTemplate()
        {
            SurveyTemplateRegularExpression = new HashSet<SurveyTemplateRegularExpression>();
        }

        [Key]
        public int SurveyTemplateId { get; set; }
        public int SurveyId { get; set; }
        public int QuestionId { get; set; }
        public bool QuestionRequired { get; set; }
        public int QuestionOrder { get; set; }
        public int? ResponseLength { get; set; }
        [StringLength(250)]
        public string Remarks { get; set; }
        public int? SectionId { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdated { get; set; }
        public int LastUpdatedBy { get; set; }

        [ForeignKey(nameof(QuestionId))]
        [InverseProperty("SurveyTemplate")]
        public virtual Question Question { get; set; }
        [ForeignKey(nameof(SectionId))]
        [InverseProperty("SurveyTemplate")]
        public virtual Section Section { get; set; }
        [ForeignKey(nameof(SurveyId))]
        [InverseProperty("SurveyTemplate")]
        public virtual Survey Survey { get; set; }
        [InverseProperty("SurveyTemplate")]
        public virtual ICollection<SurveyTemplateRegularExpression> SurveyTemplateRegularExpression { get; set; }
    }
}
