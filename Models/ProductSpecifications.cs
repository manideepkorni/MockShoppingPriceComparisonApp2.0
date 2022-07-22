using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MockShoppingPriceComparisonApp2._0.Models
{
    [Table("product_specifications")]
    public partial class ProductSpecifications
    {
        [Key]
        [Column("product_spec_id")]
        public int ProductSpecId { get; set; }
        [Column("Product_Id")]
        public int ProductId { get; set; }
        [Column("Spec_cat_id")]
        public int SpecCatId { get; set; }
        [Column("Specification_Value")]
        [StringLength(200)]
        public string SpecificationValue { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty(nameof(Products.ProductSpecifications))]
        public virtual Products Product { get; set; }
        [ForeignKey(nameof(SpecCatId))]
        [InverseProperty(nameof(SpecificationsCategoryRelation.ProductSpecifications))]
        public virtual SpecificationsCategoryRelation SpecCat { get; set; }
    }
}
