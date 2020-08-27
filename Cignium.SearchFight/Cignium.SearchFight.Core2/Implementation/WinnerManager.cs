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


            if (containerSearch == null || containerSearch.termDictionary.Count == 0)
                throw new ArgumentException("Invalid arguments", nameof(containerSearch));

            List<Search> searchWinners = GetSearchWinners(containerSearch);

            return ParseToEngineWinners(searchWinners);

        }

        public EngineTermWinner GetTotalWinner(ContainerSearch containerSearch)
        {

            if (containerSearch == null || containerSearch.termDictionary.Count == 0)
                throw new ArgumentException("Invalid arguments", nameof(containerSearch));

            // get the winner list
            List<Search> winners = GetSearchWinners(containerSearch);

            // set the first winner as a Total Winner
            Search tempTotalWinner = winners.First();

            // start iterating at position 1, for position 0 is the
            // tempTotalWinner
            for ( int i = 1; i < winners.Count; i++)
            {
                long winnerTotalResults = winners.ElementAt(i).TotalQueryResults;
                long tempWinnerTotalResults = tempTotalWinner.TotalQueryResults;

                // update total winner
                if ( winnerTotalResults > tempWinnerTotalResults)
                    tempTotalWinner = winners.ElementAt(i);

            }

            // set the engine term winner with the data of the total Winner
            EngineTermWinner engineTermWinner = new EngineTermWinner
            {
                EngineName = tempTotalWinner.EngineName,
                Term = tempTotalWinner.Term
            };

            return engineTermWinner;

        }

        private List<EngineTermWinner> ParseToEngineWinners(List<Search> searchWinners)
        {
            if ( searchWinners == null || searchWinners.Count == 0)
                throw new ArgumentException("Invalid arguments", nameof(searchWinners));

            List<EngineTermWinner> engineTermWinners = new List<EngineTermWinner>();

            foreach (Search searchWinner in searchWinners)
            {

                EngineTermWinner engineTermWinner = new EngineTermWinner
                {
                    EngineName = searchWinner.EngineName,
                    Term = searchWinner.Term
                };

                engineTermWinners.Add(engineTermWinner);

            }

            return engineTermWinners;

        }

        private List<Search> GetSearchWinners(ContainerSearch containerSearch)
        {

            if (containerSearch == null || containerSearch.termDictionary.Count == 0)
                throw new ArgumentException("Invalid arguments", nameof(containerSearch));

            var termsDictionary = containerSearch.termDictionary;

            // set the first dictionary element as a temporary search winners
            List<Search> searchWinners = SetFirstElemAsWinner(termsDictionary);

            // searchWinners is updated while iterating through the dictionary elements
            for (int i = 1; i < termsDictionary.Count; i++)
            {
                string keyTerm = termsDictionary.ElementAt(i).Key;

                List<Search> searchEngineList = termsDictionary.ElementAt(i).Value;

                for (int j = 0; j < searchEngineList.Count; j++)
                {
                    long searchMaxResult = searchWinners.ElementAt(j).TotalQueryResults;
                    long totalResults = searchEngineList.ElementAt(j).TotalQueryResults;

                    if (totalResults > searchMaxResult)
                    {
                        searchWinners.ElementAt(j).TotalQueryResults = totalResults;
                        searchWinners.ElementAt(j).Term = keyTerm;
                    }
                }
            }

            // return the search winners list 
            return searchWinners;

        }

        private List<Search> SetFirstElemAsWinner(Dictionary<string, List<Search>> termsDictionary)
        {
            if (termsDictionary == null || termsDictionary.Count == 0)
                throw new ArgumentException("Invalid arguments", nameof(termsDictionary));

            List<Search> searchWinnerListDefault = new List<Search>();

            // iterate the Serach List of first element of the dictionary
            foreach (Search search in termsDictionary.First().Value)
            {
                Search searchDefault = new Search
                {
                    EngineName = search.EngineName,
                    Term = search.Term,
                    TotalQueryResults = search.TotalQueryResults
                };

                searchWinnerListDefault.Add(searchDefault);
            }

            return searchWinnerListDefault;

        }
    }
}
