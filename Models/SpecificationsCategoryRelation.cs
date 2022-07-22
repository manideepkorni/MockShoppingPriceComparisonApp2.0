using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MockShoppingPriceComparisonApp2._0.Models
{
    [Table("Specifications_Category_Relation")]
    public partial class SpecificationsCategoryRelation
    {
        public SpecificationsCategoryRelation()
        {
            ProductSpecifications = new HashSet<ProductSpecifications>();
        }

        [Key]
        [Column("Spec_cat_rel_id")]
        public int SpecCatRelId { get; set; }
        [Column("Specification_Id")]
        public int SpecificationId { get; set; }
        [Column("Category_Id")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("SpecificationsCategoryRelation")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(SpecificationId))]
        [InverseProperty(nameof(Specifications.SpecificationsCategoryRelation))]
        public virtual Specifications Specification { get; set; }
        [InverseProperty("SpecCat")]
        public virtual ICollection<ProductSpecifications> ProductSpecifications { get; set; }
    }
}
