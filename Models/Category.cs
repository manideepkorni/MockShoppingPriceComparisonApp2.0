using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MockShoppingPriceComparisonApp2._0.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Products>();
            SpecificationsCategoryRelation = new HashSet<SpecificationsCategoryRelation>();
        }

        [Key]
        [Column("Category_Id")]
        public int CategoryId { get; set; }
        [Required]
        [Column("Category_Name")]
        [StringLength(100)]
        public string CategoryName { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<Products> Products { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<SpecificationsCategoryRelation> SpecificationsCategoryRelation { get; set; }
    }
}
