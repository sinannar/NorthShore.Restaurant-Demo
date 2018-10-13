using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthShore.Restaurant.Restaurant
{
    public class Food : Entity<long>
    {
        public int Calorie { get; set; }
        public string Name { get; set; }
        public bool IsGlutenFree { get; set; }
        public bool IsDairyFree { get; set; }
        public bool IsNutFree { get; set; }
        public decimal Price{get;set;}

        public IEnumerable<FoodMenuMapping> MenuMappings { get; set; }
    }
}
