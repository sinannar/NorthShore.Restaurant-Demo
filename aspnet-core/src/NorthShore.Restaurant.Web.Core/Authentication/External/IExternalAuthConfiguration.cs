using System.Collections.Generic;

namespace NorthShore.Restaurant.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
