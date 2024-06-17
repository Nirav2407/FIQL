using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.API.Models
{
    [Table("RegularExpression", Schema = "GSS")]
    public partial class RegularExpression
    {
        public RegularExpression()
        {
            SurveyTemplateRegularExpression = new HashSet<SurveyTemplateRegularExpression>();
        }

        [Key]
        public int RegularExpressionId { get; set; }
        [Required]
        [StringLength(100)]
        public string RegularExpressionName { get; set; }
        [StringLength(500)]
        public string RegularExpressionDescription { get; set; }
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

        [InverseProperty("RegularExpression")]
        public virtual ICollection<SurveyTemplateRegularExpression> SurveyTemplateRegularExpression { get; set; }
    }
}
