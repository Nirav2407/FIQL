using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.API.Models
{
    public partial class VwApplication
    {
        public int ApplicationId { get; set; }
        [Required]
        [StringLength(64)]
        public string ApplicationName { get; set; }
        [StringLength(50)]
        public string ShortName { get; set; }
        [StringLength(256)]
        public string Url { get; set; }
        [StringLength(8)]
        public string ApplicationType { get; set; }
        public bool IsActive { get; set; }
    }
}
