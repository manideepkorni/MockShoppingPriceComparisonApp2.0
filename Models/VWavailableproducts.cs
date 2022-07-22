using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MockShoppingPriceComparisonApp2._0.Models
{
    public partial class VWavailableproducts
    {
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Brand { get; set; }
        [Required]
        [StringLength(100)]
        public string Category { get; set; }
        public int Price { get; set; }
        public int Rating { get; set; }
    }
}
