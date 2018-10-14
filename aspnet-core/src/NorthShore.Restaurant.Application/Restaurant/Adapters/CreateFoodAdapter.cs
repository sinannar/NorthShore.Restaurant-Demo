using NorthShore.Restaurant.Restaurant.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthShore.Restaurant.Restaurant.Adapters
{
    public class CreateFoodAdapter
    {
        public Food Transform(CreateFoodDto dto)
        {
            return new Food
            {
                Name = dto.Name,
                Calorie = dto.Calorie
            };
        }
    }
}
