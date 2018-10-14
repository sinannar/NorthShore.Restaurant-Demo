using Abp.Authorization;
using Abp.Domain.Repositories;
using NorthShore.Restaurant.Restaurant.Adapters;
using NorthShore.Restaurant.Restaurant.Dto;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthShore.Restaurant.Restaurant
{
    public class RestaurantAppService : RestaurantAppServiceBase, IRestaurantAppService
    {
        private IRestaurantManager _restaurantManager { get; set; }
        private IRepository<Food, long> _foodRepository { get; set; }
        private IRepository<Menu, long> _menuRepository { get; set; }

        public RestaurantAppService(
            IRestaurantManager restaurantManager,
            IRepository<Food, long> foodRepository,
            IRepository<Menu, long> menuRepository
            )
        {
            _restaurantManager = restaurantManager;
            _foodRepository = foodRepository;
            _menuRepository = menuRepository;
        }

        public async Task CreateFood(CreateFoodDto requestDto)
        {
            var adapter = new CreateFoodAdapter();
            await _restaurantManager.CreateFood(adapter.Transform(requestDto));
        }

        public async Task CreateMenu(CreateMenuDto requestDto){
            var adapter = new CreateMenuAdapter();
            await _restaurantManager.CreateMenu(adapter.Transform(requestDto));
        }

        public async Task EditFood(EditFoodDto request)
        { 
            var entity = _foodRepository.Get(request.Id);
            if (entity != null)
            {
                var adapter = new EditFoodAdapter();
                await _restaurantManager.EditFood(adapter.Transform(request, entity));
            }
            else
            {
                throw new Exception("Given food is not found to delete");
            }
        }

        public async Task DeleteFood(long requestId)
        {
            Food entity = await _foodRepository.GetAsync(requestId);
            if (entity != null)
            {
                await _restaurantManager.DeleteFood(entity);
            }
            else
            {
                throw new Exception("Given food is not found to delete");
            }
            
        }

        public async Task DeleteMenu(long requestId)
        {
            Menu entity = await _menuRepository.GetAsync(requestId);
            if (entity != null)
            {
                await _restaurantManager.DeleteMenu(entity);
            }
            else
            {
                throw new Exception("Given menu is not found to delete");
            }
        }

        public List<ShowFoodDto> ListFoods()
        {
            var adapter = new ListFoodAdapter();
            var list = _restaurantManager.ListFood();
            return adapter.Transform(list);
        }

        public List<ShowMenuDto> ListMenus()
        {
            var adapter = new ListMenuAdapter();
            var list = _restaurantManager.ListMenu();
            return adapter.Transform(list);
        }

        public List<ShowFoodDto> ListFoodsInMenu(long menuId)
        {
            var menu = _restaurantManager.GetMenuWithMappings(menuId);
            if(menu != null)
            {
                var menuFoodMappings = menu.FoodMappings;
                var mappedFoods = _restaurantManager.ListMenuFoods(menuFoodMappings);
                var adapter = new ListFoodAdapter();
                return adapter.Transform(mappedFoods);
            }
            else
            {
                throw new Exception("Given menu is not found");
            }
        }

        public List<ShowFoodDto> ListFoodsNotInMenu(long menuId)
        {
            var menu = _restaurantManager.GetMenuWithMappings(menuId);
            if(menu != null)
            {
                var menuFoodMappings = menu.FoodMappings;
                var mappedFoods = _restaurantManager.ListNonMenuFoods(menuFoodMappings);
                var adapter = new ListFoodAdapter();
                return adapter.Transform(mappedFoods);
            }
            else
            {
                throw new Exception("Given menu is not found");
            }
        }

        public async Task AddFoodToMenu(AddFoodToMenuDto request){
            await _restaurantManager.CreateFoodMenuMapping(request.FoodIds, request.MenuId);
            await UnitOfWorkManager.Current.SaveChangesAsync();
            await _restaurantManager.UpdateMenuValues(request.MenuId);
        }

        public async Task RemoveFoodFromMenu(RemoveFoodFromMenuDto request){
            await _restaurantManager.DeleteFoodMenuMapping(request.FoodId, request.MenuId);
            await UnitOfWorkManager.Current.SaveChangesAsync();
            await _restaurantManager.UpdateMenuValues(request.MenuId);
        }
    }
}
