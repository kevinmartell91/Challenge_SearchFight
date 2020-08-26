namespace Cignium.SearchFight.Services.Models.Config
{
    public class BingConfig: BaseConfig
    {
        public static string BaseUri = GetFromAppConfig("Bing.UriBase");
        public static string AccessKey = GetFromAppConfig("Bing.AccessKey");

    }
}
