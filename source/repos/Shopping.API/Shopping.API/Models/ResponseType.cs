using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.API.Models
{
    [Table("ResponseType", Schema = "GSS")]
    public partial class ResponseType
    {
        public ResponseType()
        {
            Response = new HashSet<Response>();
        }

        [Key]
        public int ResponseTypeId { get; set; }
        [Required]
        [StringLength(100)]
        public string ResponseTypeName { get; set; }
        [Required]
        [StringLength(5)]
        public string ResponseTypeCode { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdated { get; set; }
        public int LastUpdatedBy { get; set; }

        [InverseProperty("ResponseType")]
        public virtual ICollection<Response> Response { get; set; }
    }
}
