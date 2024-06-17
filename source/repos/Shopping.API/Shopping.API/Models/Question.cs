using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.API.Models
{
    [Table("Question", Schema = "GSS")]
    public partial class Question
    {
        public Question()
        {
            QuestionResponse = new HashSet<QuestionResponse>();
            SurveyTemplate = new HashSet<SurveyTemplate>();
            SurveyTemplateRegularExpression = new HashSet<SurveyTemplateRegularExpression>();
        }

        [Key]
        public int QuestionId { get; set; }
        [Required]
        [StringLength(250)]
        public string QuestionText { get; set; }
        public int QuestionTypeId { get; set; }
        public int DepartmentId { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdated { get; set; }
        public int LastUpdatedBy { get; set; }

        [ForeignKey(nameof(QuestionTypeId))]
        [InverseProperty("Question")]
        public virtual QuestionType QuestionType { get; set; }
        [InverseProperty("Question")]
        public virtual ICollection<QuestionResponse> QuestionResponse { get; set; }
        [InverseProperty("Question")]
        public virtual ICollection<SurveyTemplate> SurveyTemplate { get; set; }
        [InverseProperty("Question")]
        public virtual ICollection<SurveyTemplateRegularExpression> SurveyTemplateRegularExpression { get; set; }
    }
}
