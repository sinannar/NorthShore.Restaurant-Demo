using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace NorthShore.Restaurant.Localization
{
    public static class RestaurantLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(RestaurantConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(RestaurantLocalizationConfigurer).GetAssembly(),
                        "NorthShore.Restaurant.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
