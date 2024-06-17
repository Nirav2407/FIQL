using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.API.Models
{
    [Table("Survey", Schema = "GSS")]
    public partial class Survey
    {
        public Survey()
        {
            SurveyAccess = new HashSet<SurveyAccess>();
            SurveyFieldRule = new HashSet<SurveyFieldRule>();
            SurveyTemplate = new HashSet<SurveyTemplate>();
        }

        [Key]
        public int SurveyId { get; set; }
        [Required]
        [StringLength(100)]
        public string SurveyName { get; set; }
        [Required]
        [StringLength(250)]
        public string SurveyDescription { get; set; }
        public int SurveySubTypeId { get; set; }
        public int DepartmentId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdated { get; set; }
        public int LastUpdatedBy { get; set; }

        [ForeignKey(nameof(SurveySubTypeId))]
        [InverseProperty("Survey")]
        public virtual SurveySubType SurveySubType { get; set; }
        [InverseProperty("Survey")]
        public virtual ICollection<SurveyAccess> SurveyAccess { get; set; }
        [InverseProperty("Survey")]
        public virtual ICollection<SurveyFieldRule> SurveyFieldRule { get; set; }
        [InverseProperty("Survey")]
        public virtual ICollection<SurveyTemplate> SurveyTemplate { get; set; }
    }
}
