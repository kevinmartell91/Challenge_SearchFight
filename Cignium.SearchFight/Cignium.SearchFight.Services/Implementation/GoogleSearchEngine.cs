using System;
using System.Net.Http;
using System.Threading.Tasks;
using Cignium.SearchFight.Services.Interfaces;
using Cignium.SearchFight.Services.Models.Config;
using Cignium.SearchFight.Services.Models.Google;
using Cignium.SearchFight.Shared.Helpers;

namespace Cignium.SearchFight.Services.Implementation
{
    public class GoogleSearchEngine : ISearchEngine
    {

        public string Name => "Google";
        private HttpClient _client { get; }

        public GoogleSearchEngine ()
        {
            _client = new HttpClient();
        }

        public async Task<long> GetTotalResultsAsync(string query)
        {
            if ( string.IsNullOrEmpty(query) )
                throw new ArgumentException("The term cannot be null or empty",
                    nameof(query));

            string customSearchRequestUri = GoogleConfig.BaseUrl
                    .Replace("{ApiKey}", GoogleConfig.ApiKey)
                    .Replace("{Context}", GoogleConfig.Cx)
                    .Replace("{Query}", query);

            var response = await _client.GetAsync(customSearchRequestUri);

            using (response)
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Request not processed.");

                GoogleResponse results = JsonHelper
                    .Deserialize<GoogleResponse>
                        (await response.Content.ReadAsStringAsync());

                return long.Parse(results.searchInformation.totalResults);
            }
        }
    }
}
