using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MockShoppingPriceComparisonApp2._0.Models
{
    public partial class Comparison
    {
        public Comparison()
        {
            ComparisonFeedback = new HashSet<ComparisonFeedback>();
        }

        [Key]
        [Column("Comparison_Id")]
        public int ComparisonId { get; set; }
        [Column("User_Id")]
        public int UserId { get; set; }
        [Column("Comparison_Date", TypeName = "date")]
        public DateTime ComparisonDate { get; set; }
        [Column("Product_Id1")]
        public int ProductId1 { get; set; }
        [Column("Product_Id2")]
        public int ProductId2 { get; set; }
        [Column("Product_Id3")]
        public int? ProductId3 { get; set; }
        [Column("Product_Id4")]
        public int? ProductId4 { get; set; }

        [ForeignKey(nameof(ProductId1))]
        [InverseProperty(nameof(Products.ComparisonProductId1Navigation))]
        public virtual Products ProductId1Navigation { get; set; }
        [ForeignKey(nameof(ProductId2))]
        [InverseProperty(nameof(Products.ComparisonProductId2Navigation))]
        public virtual Products ProductId2Navigation { get; set; }
        [ForeignKey(nameof(ProductId3))]
        [InverseProperty(nameof(Products.ComparisonProductId3Navigation))]
        public virtual Products ProductId3Navigation { get; set; }
        [ForeignKey(nameof(ProductId4))]
        [InverseProperty(nameof(Products.ComparisonProductId4Navigation))]
        public virtual Products ProductId4Navigation { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.Comparison))]
        public virtual Users User { get; set; }
        [InverseProperty("Comparison")]
        public virtual ICollection<ComparisonFeedback> ComparisonFeedback { get; set; }
    }
}
