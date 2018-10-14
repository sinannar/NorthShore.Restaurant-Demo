using NorthShore.Restaurant.Restaurant.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthShore.Restaurant.Restaurant.Adapters
{
    public class CreateMenuAdapter
    {
        public Menu Transform(CreateMenuDto dto)
        {
            return new Menu
            {
                Name = dto.Name,
                DiscountRate = dto.DiscountRate
            };
        }
    }
}
