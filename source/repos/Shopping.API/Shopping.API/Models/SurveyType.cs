using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.API.Models
{
    [Table("SurveyType", Schema = "GSS")]
    public partial class SurveyType
    {
        public SurveyType()
        {
            SurveySubType = new HashSet<SurveySubType>();
        }

        [Key]
        public int SurveyTypeId { get; set; }
        [Required]
        [StringLength(250)]
        public string SurveyTypeName { get; set; }
        [StringLength(250)]
        public string SurveyTypeDescription { get; set; }
        public int DepartmentId { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdated { get; set; }
        public int LastUpdatedBy { get; set; }

        [InverseProperty("SurveyType")]
        public virtual ICollection<SurveySubType> SurveySubType { get; set; }
    }
}
