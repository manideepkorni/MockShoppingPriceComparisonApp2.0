using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace MockShoppingPriceComparisonApp2._0.Models
{
    public partial class Products
    {
        public Products()
        {
            ComparisonProductId1Navigation = new HashSet<Comparison>();
            ComparisonProductId2Navigation = new HashSet<Comparison>();
            ComparisonProductId3Navigation = new HashSet<Comparison>();
            ComparisonProductId4Navigation = new HashSet<Comparison>();
            ProductFeedback = new HashSet<ProductFeedback>();
            ProductSpecifications = new HashSet<ProductSpecifications>();
        }

        [Key]
        [Column("Product_Id")]
        public int ProductId { get; set; }
        [Required]
        [Column("Product_Name")]
        public string ProductName { get; set; }
        [Required]
        [Column("Product_Image")]
        public string ProductImage { get; set; }
        [Column("Brand_Id")]
        public int BrandId { get; set; }
        [Column("Category_Id")]
        public int CategoryId { get; set; }
        [Column("Product_Price")]
        public double ProductPrice { get; set; }
        [Column("Product_Rating")]
        public int ProductRating { get; set; }
        [Required]
        [Column("Product_Availability")]
        [StringLength(20)]
        public string ProductAvailability { get; set; }
        public bool Isdeleted { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DeletedDate { get; set; }

        [ForeignKey(nameof(BrandId))]
        [InverseProperty(nameof(Brands.Products))]
        public virtual Brands Brand { get; set; }
        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Products")]
        public virtual Category Category { get; set; }
        [InverseProperty(nameof(Comparison.ProductId1Navigation))]
        public virtual ICollection<Comparison> ComparisonProductId1Navigation { get; set; }
        [InverseProperty(nameof(Comparison.ProductId2Navigation))]
        public virtual ICollection<Comparison> ComparisonProductId2Navigation { get; set; }
        [InverseProperty(nameof(Comparison.ProductId3Navigation))]
        public virtual ICollection<Comparison> ComparisonProductId3Navigation { get; set; }
        [InverseProperty(nameof(Comparison.ProductId4Navigation))]
        public virtual ICollection<Comparison> ComparisonProductId4Navigation { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<ProductFeedback> ProductFeedback { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<ProductSpecifications> ProductSpecifications { get; set; }
    }
}
