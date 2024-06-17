using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.API.Models
{
    public partial class VwDepartment
    {
        public int DepartmentId { get; set; }
        public int? DivisionId { get; set; }
        [StringLength(32)]
        public string DepartmentName { get; set; }
        [StringLength(8)]
        public string DepartmentShortName { get; set; }
        public int? ParentDepartmentId { get; set; }
        public int? DepartmentEntityStructureId { get; set; }
        public bool? SatsangActivity { get; set; }
        [StringLength(4)]
        public string Wing { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        public int? CreatedBy { get; set; }
        public int? LastUpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdated { get; set; }
    }
}
