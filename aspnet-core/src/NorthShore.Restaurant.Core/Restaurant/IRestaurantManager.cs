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

        Task CreateMenu(Menu menu);
        Task DeleteMenu(Menu menu);
        IQueryable<Menu> ListMenu();
        Menu GetMenuWithMappings(long menuId);

        IQueryable<Food> ListMenuFoods(IEnumerable<FoodMenuMapping> mapping);
        IQueryable<Food> ListNonMenuFoods(IEnumerable<FoodMenuMapping> mapping);
        IQueryable<Menu> ListFoodMenus(IEnumerable<FoodMenuMapping> mapping);

        Task DeleteFoodMenuMapping(long foodId, long menuId);
        Task DeleteFoodMenuMapping(FoodMenuMapping mapping);
        Task CreateFoodMenuMapping(long foodId, long menuId);
        Task CreateFoodMenuMapping(long foodId, List<long> menuIds);
        Task CreateFoodMenuMapping(List<long> foodIds, long menuId);
        Task UpdateMenuValues(long menuId);
    }
}
