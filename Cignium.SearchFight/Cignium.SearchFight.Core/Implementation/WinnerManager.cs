using System;
using System.Collections.Generic;
using System.Linq;
using Cignium.SearchFight.Core.Interfaces;
using Cignium.SearchFight.Core.Models;

namespace Cignium.SearchFight.Core.Implementation
{
    public class WinnerManager : IWinnerManager
    {
        
        public List<EngineTermWinner> GetEngineWinners(ContainerSearch containerSearch)
        {

            var termsDictionary = containerSearch.termDictionary;
            if (containerSearch == null || termsDictionary.Count == 0)
                throw new Exception();

            List<Search> tempWinners = GetTempWinners(containerSearch);

            return GetWinners(tempWinners);
        }

        public EngineTermWinner GetTotalWinner(ContainerSearch containerSearch)
        {

            var termsDictionary = containerSearch.termDictionary;
            if (containerSearch == null || termsDictionary.Count == 0)
                throw new Exception();

            List<Search> winners = GetTempWinners(containerSearch);
            Search tempTotalWinner = winners.First();
            EngineTermWinner engineTermWinner = new EngineTermWinner();

            for( int i = 0; i> winners.Count; i++)
            {
                long winnerTotalResults = winners.ElementAt(i).TotalQueryResults;
                if ( winnerTotalResults > tempTotalWinner.TotalQueryResults)
                    tempTotalWinner = winners.ElementAt(i);
            }

            engineTermWinner.EngineName = tempTotalWinner.EngineName;
            engineTermWinner.Term = tempTotalWinner.Term;

            return engineTermWinner;
        }

        private List<EngineTermWinner> GetWinners(List<Search> SearchWinners)
        {
            List<EngineTermWinner> engineTermWinners = new List<EngineTermWinner>();
            EngineTermWinner engineTermWinner = new EngineTermWinner();

            foreach (Search searchWinner in SearchWinners)
            {
                engineTermWinner.EngineName = searchWinner.EngineName;
                engineTermWinner.Term = searchWinner.Term;
                engineTermWinners.Add(engineTermWinner);
            }
            return engineTermWinners;
        }


        private List<Search> GetTempWinners( ContainerSearch containerSearch)
        {
            var termsDictionary = containerSearch.termDictionary;
            if (containerSearch == null || termsDictionary.Count == 0)
                throw new Exception();

            List<Search> tempWinners = SetFirstElemAsWinner(termsDictionary);

            // tempWinners is updated while iterating through the dictionary
            for (int i = 1; i < termsDictionary.Count; i++)
            {
                string keyTerm = termsDictionary.ElementAt(i).Key;
                List<Search> searchEngineList = termsDictionary.ElementAt(i).Value;

                for (int j = 0; j < searchEngineList.Count; j++)
                {
                    long tempMaxResult = tempWinners.ElementAt(j).TotalQueryResults;
                    long totalResults = searchEngineList.ElementAt(j).TotalQueryResults;
                    if (totalResults > tempMaxResult)
                    {
                        tempWinners.ElementAt(j).TotalQueryResults = totalResults;
                        tempWinners.ElementAt(j).Term = keyTerm;
                    }
                }
            }
            return tempWinners;
        }

 
        /// <summary>
        /// Setting the first element of the dictionary as winner
        /// </summary>
        /// <param name="termsDictionary"></param>
        /// <returns> A list of all the search engines as a winners</returns>
        private List<Search> SetFirstElemAsWinner(Dictionary<string, List<Search>> termsDictionary)
        {
            List<Search> searchWinnerListDefault = new List<Search>();

            Search searchDefault = new Search();

            // iterate the Serach List of first element of the dictionary
            foreach (Search search in termsDictionary.First().Value)
            {
                searchDefault.EngineName = search.EngineName;
                searchDefault.Term = search.Term;
                searchDefault.TotalQueryResults = search.TotalQueryResults;

                searchWinnerListDefault.Add(searchDefault);
            }
            return searchWinnerListDefault;
        }
    }
}
