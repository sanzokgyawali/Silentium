using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AnonymousChat.Localization
{
    public static class AnonymousChatLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AnonymousChatConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AnonymousChatLocalizationConfigurer).GetAssembly(),
                        "AnonymousChat.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
