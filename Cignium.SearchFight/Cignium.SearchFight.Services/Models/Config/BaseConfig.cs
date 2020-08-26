using System.Configuration;

namespace Cignium.SearchFight.Services.Models.Config
{
    public class BaseConfig
    {
        private const string NO_KEY_CONFIG = "There is no such key ({Key}) in App.config file.";

        public static string GetFromAppConfig(string key)
        {
            string configValue = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrEmpty(configValue))
                throw new ConfigurationErrorsException(NO_KEY_CONFIG.Replace("{Key}", key));

            return configValue;
        }
    }
}
