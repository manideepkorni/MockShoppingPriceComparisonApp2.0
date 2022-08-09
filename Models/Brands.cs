using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace MockShoppingPriceComparisonApp2._0.Models
{
    public partial class Brands
    {
        public Brands()
        {
            Products = new HashSet<Products>();
        }

        [Key]
        [Column("Brand_Id")]
        public int BrandId { get; set; }
        [Required]
        [Column("Brand_Name")]
        [StringLength(100)]
        public string BrandName { get; set; }

        [InverseProperty("Brand")]
        public virtual ICollection<Products> Products { get; set; }
    }
}
