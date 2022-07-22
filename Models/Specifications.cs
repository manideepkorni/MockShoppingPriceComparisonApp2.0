using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MockShoppingPriceComparisonApp2._0.Models
{
    public partial class Specifications
    {
        public Specifications()
        {
            SpecificationsCategoryRelation = new HashSet<SpecificationsCategoryRelation>();
        }

        [Key]
        [Column("Specification_Id")]
        public int SpecificationId { get; set; }
        [Required]
        [Column("Specification_Name")]
        [StringLength(100)]
        public string SpecificationName { get; set; }

        [InverseProperty("Specification")]
        public virtual ICollection<SpecificationsCategoryRelation> SpecificationsCategoryRelation { get; set; }
    }
}
