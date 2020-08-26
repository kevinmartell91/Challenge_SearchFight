using System.Collections.Generic;
using System.Threading.Tasks;
using Cignium.SearchFight.Core.Models;

namespace Cignium.SearchFight.Core.Interfaces
{
    public interface ISearchManager
    {
        /// <summary>
        /// Get a list of different search engine results 
        /// </summary>
        /// <param name="terms"></param> a list of terms to be queried
        /// <returns> A list of results from different search engines </returns>
        Task<ContainerSearch> GetSearchEngineResults(IList<string> terms);
    }
}
