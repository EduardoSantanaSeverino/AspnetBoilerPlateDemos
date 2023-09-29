using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace MyCollegeV2.Localization
{
    public static class MyCollegeV2LocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(MyCollegeV2Consts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(MyCollegeV2LocalizationConfigurer).GetAssembly(),
                        "MyCollegeV2.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
