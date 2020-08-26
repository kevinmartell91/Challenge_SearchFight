namespace Cignium.SearchFight.Services.Models.Config
{
    public class GoogleConfig: BaseConfig
    {
        public static string BaseUrl = GetFromAppConfig("Google.BaseUrl");
        public static string ApiKey = GetFromAppConfig("Google.ApiKey");
        public static string Cx = GetFromAppConfig("Google.Cx");
    }
}
