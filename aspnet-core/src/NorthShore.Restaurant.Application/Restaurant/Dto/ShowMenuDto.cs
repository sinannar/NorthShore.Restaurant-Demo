using System;
using System.Collections.Generic;
using System.Text;

namespace NorthShore.Restaurant.Restaurant.Dto
{
    public class ShowMenuDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal TotalCalorie{get;set;}
        public decimal TotalPrice{get;set;}
        public decimal DiscountedPrice{get;set;}
    }
}
