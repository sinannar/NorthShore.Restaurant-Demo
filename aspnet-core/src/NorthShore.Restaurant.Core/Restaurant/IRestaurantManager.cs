using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthShore.Restaurant.Restaurant
{
    public interface IRestaurantManager
    {
        Task CreateFood(Food food);
        Task EditFood(Food food);
        Task DeleteFood(Food food);
        IQueryable<Food> ListFood();
    }
}
