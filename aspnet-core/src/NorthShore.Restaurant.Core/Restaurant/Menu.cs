using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NorthShore.Restaurant.Restaurant
{
    public class Menu: Entity<long>
    {
        public string Name { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal TotalCalorie{get;set;}
        public decimal TotalPrice{get;set;}
        public decimal DiscountedPrice{get;set;}
        public IEnumerable<FoodMenuMapping> FoodMappings { get; set; }
    }
}
