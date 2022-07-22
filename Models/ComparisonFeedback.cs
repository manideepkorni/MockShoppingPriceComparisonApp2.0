using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MockShoppingPriceComparisonApp2._0.Models
{
    [Table("Comparison_feedback")]
    public partial class ComparisonFeedback
    {
        [Key]
        [Column("Comparison_Feedback_Id")]
        public int ComparisonFeedbackId { get; set; }
        [Column("Comparison_Id")]
        public int ComparisonId { get; set; }
        [Column("User_Id")]
        public int UserId { get; set; }
        [Column("Comparison_Feedback_rating")]
        public int? ComparisonFeedbackRating { get; set; }
        [Column("Comaprison_Feedback")]
        [StringLength(200)]
        public string ComaprisonFeedback { get; set; }

        [ForeignKey(nameof(ComparisonId))]
        [InverseProperty("ComparisonFeedback")]
        public virtual Comparison Comparison { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.ComparisonFeedback))]
        public virtual Users User { get; set; }
    }
}
