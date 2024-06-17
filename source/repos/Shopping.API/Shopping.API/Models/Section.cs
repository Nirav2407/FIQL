using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.API.Models
{
    [Table("Section", Schema = "GSS")]
    public partial class Section
    {
        public Section()
        {
            SurveyTemplate = new HashSet<SurveyTemplate>();
        }

        [Key]
        public int SectionId { get; set; }
        [Required]
        [StringLength(250)]
        public string SectionName { get; set; }
        [StringLength(1000)]
        public string SectionDescription { get; set; }
        public int DepartmentId { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdated { get; set; }
        public int LastUpdatedBy { get; set; }

        [InverseProperty("Section")]
        public virtual ICollection<SurveyTemplate> SurveyTemplate { get; set; }
    }
}
