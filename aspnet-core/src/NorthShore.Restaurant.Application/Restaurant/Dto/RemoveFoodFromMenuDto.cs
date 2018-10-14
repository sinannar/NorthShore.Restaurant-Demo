using System;
using System.Collections.Generic;
using System.Text;

namespace NorthShore.Restaurant.Restaurant.Dto
{
    public class RemoveFoodFromMenuDto
    {
        public long MenuId { get; set; }
        public long FoodId { get; set; }
    }
}
