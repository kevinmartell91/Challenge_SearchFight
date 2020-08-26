using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cignium.SearchFight.Core.Interfaces;
using Cignium.SearchFight.Services.Interfaces;
using Cignium.SearchFight.Core.Models;

namespace Cignium.SearchFight.Core.Implementation
{
    public class SearchManager : ISearchManager
    {
        private IList<ISearchEngine> _searchEngines;

        public SearchManager()
        {
            _searchEngines = retriveSearchEngines();
        }

        private static IList<ISearchEngine> retriveSearchEngines()
        {
            IList<ISearchEngine> assemblies = AppDomain.CurrentDomain.GetAssemblies()
                ?.Where(assembly => assembly.FullName.StartsWith("Cignium.SearchFight"))
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.GetInterface(typeof(ISearchEngine).ToString()) != null)
                .Select(type => Activator.CreateInstance(type) as ISearchEngine).ToList();

            return assemblies;
        }

        public async Task<ContainerSearch> GetSearchEngineResults(IList<string> terms)
        {
            if (terms.Equals(null) || terms.Count().Equals(0))
                throw new ArgumentException("The input arguments are invalid", nameof(terms));

            ContainerSearch containerSearch = new ContainerSearch();

            foreach( string term in terms)
            {
                List<Search> searchResutls = new List<Search>();
                foreach(ISearchEngine engine in _searchEngines)
                {
                    Search search = new Search();
                    search.Term = term;
                    search.EngineName = engine.Name;
                    search.TotalQueryResults = await engine.GetTotalResultsAsync(term);

                    searchResutls.Add(search);
                }
                containerSearch.termDictionary.Add(term, searchResutls);
            }
            return containerSearch;
        }
    }
}
