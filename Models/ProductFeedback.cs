using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MockShoppingPriceComparisonApp2._0.Models
{
    [Table("Product_Feedback")]
    public partial class ProductFeedback
    {
        [Key]
        [Column("Product_Feedback_ID")]
        public int ProductFeedbackId { get; set; }
        [Column("Product_Id")]
        public int ProductId { get; set; }
        [Column("User_Id")]
        public int UserId { get; set; }
        [Column("Product_Feedback_Rating")]
        public int? ProductFeedbackRating { get; set; }
        [Column("Product_Feedback")]
        [StringLength(200)]
        public string ProductFeedback1 { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty(nameof(Products.ProductFeedback))]
        public virtual Products Product { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.ProductFeedback))]
        public virtual Users User { get; set; }
    }
}
