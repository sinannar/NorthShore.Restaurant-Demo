using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthShore.Restaurant.Restaurant
{
    public class FoodMenuMapping:Entity<long>
    {
        public long FoodId { get; set; }
        public long MenuId { get; set; }
        public Food Food { get; set; }
        public Menu Menu { get; set; }
    }
}
