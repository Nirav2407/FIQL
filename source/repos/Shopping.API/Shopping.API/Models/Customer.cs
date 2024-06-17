using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.API.Models
{
    public partial class Customer
    {
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25)]
        public string LastName { get; set; }
        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }
        [StringLength(25)]
        public string EmailAddress { get; set; }
        public int Priority { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
    }
}
