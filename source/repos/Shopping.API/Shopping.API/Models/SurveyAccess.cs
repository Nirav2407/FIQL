using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.API.Models
{
    [Table("SurveyAccess", Schema = "GSS")]
    public partial class SurveyAccess
    {
        [Key]
        public int SurveyAccessId { get; set; }
        public int SurveyId { get; set; }
        [Required]
        [StringLength(3)]
        public string SurveyAccessType { get; set; }
        public int? EventId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdated { get; set; }
        public int LastUpdatedBy { get; set; }

        [ForeignKey(nameof(SurveyId))]
        [InverseProperty("SurveyAccess")]
        public virtual Survey Survey { get; set; }
    }
}
