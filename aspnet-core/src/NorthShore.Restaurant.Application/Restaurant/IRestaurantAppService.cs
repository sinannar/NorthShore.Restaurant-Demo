﻿using NorthShore.Restaurant.Restaurant.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthShore.Restaurant.Restaurant
{
    public interface IRestaurantAppService
    {
        Task CreateFood(CreateFoodDto request);
    }
}
