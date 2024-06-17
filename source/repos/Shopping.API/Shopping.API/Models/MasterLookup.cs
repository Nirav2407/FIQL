using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.API.Models
{
    [Table("MasterLookup", Schema = "GSS")]
    public partial class MasterLookup
    {
        [Key]
        [StringLength(50)]
        public string TableName { get; set; }
        [Key]
        [StringLength(50)]
        public string ColumnName { get; set; }
        [Key]
        [StringLength(20)]
        public string ColumnValue { get; set; }
        [StringLength(250)]
        public string ColumnDesc { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdated { get; set; }
        public int LastUpdatedBy { get; set; }
    }
}
