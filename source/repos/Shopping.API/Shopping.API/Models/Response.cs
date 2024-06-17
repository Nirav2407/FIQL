using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.API.Models
{
    [Table("Response", Schema = "GSS")]
    public partial class Response
    {
        public Response()
        {
            QuestionResponse = new HashSet<QuestionResponse>();
        }

        [Key]
        public int ResponseId { get; set; }
        [Required]
        [StringLength(250)]
        public string ResponseText { get; set; }
        public int ResponseTypeId { get; set; }
        public int DepartmentId { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdated { get; set; }
        public int LastUpdatedBy { get; set; }

        [ForeignKey(nameof(ResponseTypeId))]
        [InverseProperty("Response")]
        public virtual ResponseType ResponseType { get; set; }
        [InverseProperty("Response")]
        public virtual ICollection<QuestionResponse> QuestionResponse { get; set; }
    }
}
