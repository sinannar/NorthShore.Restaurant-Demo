using Microsoft.AspNetCore.Antiforgery;
using NorthShore.Restaurant.Controllers;

namespace NorthShore.Restaurant.Web.Host.Controllers
{
    public class AntiForgeryController : RestaurantControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
