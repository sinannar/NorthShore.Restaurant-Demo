using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthShore.Restaurant.Restaurant
{
    public class RestaurantManager : IDomainService, IRestaurantManager
    {
        private IRepository<Food, long> _foodRepository { get; set; }
        private IRepository<Menu, long> _menuRepository { get; set; }
        private IRepository<FoodMenuMapping, long> _foodMenuMappingRepository { get; set; }

        public RestaurantManager(
            IRepository<Food, long> foodRepository,
            IRepository<Menu, long> menuRepository,
            IRepository<FoodMenuMapping, long> foodMenuMappingRepository
            )
        {
            _foodRepository = foodRepository;
            _menuRepository = menuRepository;
            _foodMenuMappingRepository = foodMenuMappingRepository;
        }

        public async Task CreateFood(Food food)
        {
            await _foodRepository.InsertAsync(food);
        }
    }
}
