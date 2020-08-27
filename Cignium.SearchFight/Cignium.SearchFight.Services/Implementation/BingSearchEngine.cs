using System;
using System.Net.Http;
using System.Threading.Tasks;
using Cignium.SearchFight.Services.Interfaces;
using Cignium.SearchFight.Services.Models.Bing;
using Cignium.SearchFight.Services.Models.Config;
using Cignium.SearchFight.Shared.Helpers;

namespace Cignium.SearchFight.Services.Implementation
{
    public class BingSearchEngine: ISearchEngine, IRequestHeaders
    {
        
        public string Name => "Bing";
        private HttpClient _client { get; }

        public BingSearchEngine()
        {
            _client = new HttpClient();
            setRequestHeaders();
        }

        public async Task<long> GetTotalResultsAsync(string searchQuery)
        {
            if (string.IsNullOrEmpty(searchQuery))
                throw new ArgumentException("The term cannot be null or empty",
                    nameof(searchQuery));

            string customSearchRequestUri =
                BingConfig.BaseUri.Replace("{Query}", searchQuery);

            var response = await _client.GetAsync(customSearchRequestUri);

            using ( response )
            {
                BingResponse results =
                    JsonHelper.Deserialize<BingResponse>
                        (await response.Content.ReadAsStringAsync());

                return long.Parse(results.webPages.totalEstimatedMatches);
            }
        }

        public void setRequestHeaders()
        {
            _client.DefaultRequestHeaders
                .Add(
                    "Ocp-Apim-Subscription-Key",
                    BingConfig.AccessKey
                );
        }
    }
}
