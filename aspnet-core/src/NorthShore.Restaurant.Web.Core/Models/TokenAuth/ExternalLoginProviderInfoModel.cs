using Abp.AutoMapper;
using NorthShore.Restaurant.Authentication.External;

namespace NorthShore.Restaurant.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
