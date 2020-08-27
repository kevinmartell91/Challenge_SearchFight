using System;
using System.Collections.Generic;
using System.Text;
using Cignium.SearchFight.Core.Interfaces;
using Cignium.SearchFight.Core.Models;

namespace Cignium.SearchFight.Core.Implementation
{
    public class ReportManager: IReportManager
    {

        public const string TOTAL_WINNER_MESSAGE = "Total winner: ";
        public const string WINNER_MESSAGE = " winner: ";

        public IList<string> PrintSearchResults(ContainerSearch containerSearch)
        {

            if (containerSearch == null || containerSearch.termDictionary.Count == 0)
                throw new ArgumentException("The parameter is invalid", nameof(containerSearch));

            var termsDictionary = containerSearch.termDictionary;

            List<string> searchResults = new List<string>();

            StringBuilder resultBuilder = new StringBuilder();

            foreach( var termDict in termsDictionary)
            {
                resultBuilder.Append(termDict.Key);
                resultBuilder.Append(": ");

                foreach( var search in termDict.Value)
                {
                    resultBuilder.Append(search.EngineName);
                    resultBuilder.Append(": ");
                    resultBuilder.Append(search.TotalQueryResults);
                    resultBuilder.Append(" ");
                }

                searchResults.Add(resultBuilder.ToString());

                resultBuilder.Clear();
            }

            return searchResults;
            
        }

        public IList<string> PrintWinners(IList<EngineTermWinner> engineTermWinners)
        {
            if (engineTermWinners == null || engineTermWinners.Count == 0)
                throw new ArgumentException("The parameter is invalid", nameof(engineTermWinners));

            List<string> winners = new List<string>();

            StringBuilder winnerBuilder = new StringBuilder();

            foreach( EngineTermWinner winner in engineTermWinners)
            {
                winnerBuilder.Append(winner.EngineName);
                winnerBuilder.Append(WINNER_MESSAGE);
                winnerBuilder.Append(winner.Term);

                winners.Add(winnerBuilder.ToString());

                winnerBuilder.Clear();
            }

            return winners;

        }

        public string PrintTotalWinner(EngineTermWinner totalWinner)
        {
            if(totalWinner == null)
                throw new ArgumentException("The parameter is invalid", nameof(totalWinner));

            StringBuilder totalWinnerBuilder = new StringBuilder();
            totalWinnerBuilder.Append(TOTAL_WINNER_MESSAGE);
            totalWinnerBuilder.Append(totalWinner.Term);

            return totalWinnerBuilder.ToString();

        }

    }
}
