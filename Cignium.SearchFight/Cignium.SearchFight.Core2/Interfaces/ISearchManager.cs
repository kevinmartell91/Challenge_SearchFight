using System.Collections.Generic;
using System.Threading.Tasks;
using Cignium.SearchFight.Core.Models;

namespace Cignium.SearchFight.Core.Interfaces
{
    public interface ISearchManager
    {
        /// <summary>
        /// Create an object that will store a data structure (dictionary)
        /// of the search fight.  
        /// </summary>
        /// <param name="terms"></param> A list of terms to be queried by
        /// every available search engine.
        /// <returns> A container object that has a dictionary. The Key
        /// is query term and the Value is a list of engines with their
        /// search results. </returns>
        Task<ContainerSearch> GetSearchEngineResults(IList<string> terms);
    }
}
