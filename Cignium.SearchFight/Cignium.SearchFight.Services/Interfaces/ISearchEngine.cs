using System.Threading.Tasks;

namespace Cignium.SearchFight.Services.Interfaces
{

    public interface ISearchEngine
    {

        /// <summary>
        /// Name of the serach engine
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Get total results from a given search engine
        /// </summary>
        /// <param name="query"> term to be queried
        /// by a given search engine </param>
        /// <returns></returns>
        Task<long> GetTotalResultsAsync(string query);

    }
}
