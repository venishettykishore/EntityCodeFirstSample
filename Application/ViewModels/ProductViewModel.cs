using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{

    /// <summary>
    /// Product View model to display on the Product view
    /// </summary>
    public class ProductViewModel 
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int StockCount { get; set; }
    }
}