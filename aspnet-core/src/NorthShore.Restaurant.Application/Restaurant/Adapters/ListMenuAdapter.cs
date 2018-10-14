using NorthShore.Restaurant.Restaurant.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthShore.Restaurant.Restaurant.Adapters
{
    public class ListMenuAdapter
    {
        public List<ShowMenuDto> Transform(IQueryable<Menu> list)
        {
            return list.Select(menu => new ShowMenuDto
            {
                Id = menu.Id,
                Name = menu.Name,
                DiscountRate = menu.DiscountRate,
                TotalCalorie = menu.TotalCalorie,
                TotalPrice = menu.TotalPrice,
                DiscountedPrice = menu.DiscountedPrice,
            }).ToList();
        }
    }
}
