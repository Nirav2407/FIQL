using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.API.Models
{
    [Table("SurveySubType", Schema = "GSS")]
    public partial class SurveySubType
    {
        public SurveySubType()
        {
            Survey = new HashSet<Survey>();
        }

        [Key]
        public int SurveySubTypeId { get; set; }
        public int SurveyTypeId { get; set; }
        [Required]
        [StringLength(200)]
        public string SurveySubTypeName { get; set; }
        [StringLength(500)]
        public string SurveySubTypeDescription { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdated { get; set; }
        public int LastUpdatedBy { get; set; }

        [ForeignKey(nameof(SurveyTypeId))]
        [InverseProperty("SurveySubType")]
        public virtual SurveyType SurveyType { get; set; }
        [InverseProperty("SurveySubType")]
        public virtual ICollection<Survey> Survey { get; set; }
    }
}
