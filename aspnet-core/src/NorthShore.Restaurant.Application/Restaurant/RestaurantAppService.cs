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
    }
}
