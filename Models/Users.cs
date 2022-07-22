using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MockShoppingPriceComparisonApp2._0.Models
{
    public partial class Users
    {
        public Users()
        {
            Comparison = new HashSet<Comparison>();
            ComparisonFeedback = new HashSet<ComparisonFeedback>();
            ProductFeedback = new HashSet<ProductFeedback>();
        }

        [Key]
        [Column("User_Id")]
        public int UserId { get; set; }
        [Required]
        [Column("User_Name")]
        public string UserName { get; set; }
        [Required]
        [Column("User_GivenName")]
        public string UserGivenName { get; set; }
        [Required]
        [Column("User_Gender")]
        [StringLength(1)]
        public string UserGender { get; set; }
        [Column("User_Age")]
        public int UserAge { get; set; }
        [Required]
        [Column("User_Email")]
        [StringLength(100)]
        public string UserEmail { get; set; }
        [Required]
        [Column("User_Password")]
        [StringLength(100)]
        public string UserPassword { get; set; }
        [Required]
        [Column("User_Address")]
        public string UserAddress { get; set; }
        [Required]
        [Column("User_Role")]
        [StringLength(40)]
        public string UserRole { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Comparison> Comparison { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<ComparisonFeedback> ComparisonFeedback { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<ProductFeedback> ProductFeedback { get; set; }
    }
}
