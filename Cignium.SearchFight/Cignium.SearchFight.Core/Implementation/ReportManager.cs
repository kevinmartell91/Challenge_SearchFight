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

        public ReportManager()
        {
        }

        public IList<string> PrintSearchResults(ContainerSearch containerSearch)
        {
            var termsDictionary = containerSearch.termDictionary;
            if (containerSearch == null || termsDictionary.Count == 0)
                throw new ArgumentException("The parameter is invalid", nameof(containerSearch));

            List<string> results = new List<string>();
            StringBuilder tempResult = new StringBuilder();

            foreach( var termDict in termsDictionary)
            {
                tempResult.Append(termDict.Key);

                foreach( var search in termDict.Value)
                {
                    tempResult.Append(": " + search.EngineName + ": " + search.TotalQueryResults + " ");
                }
                results.Add(tempResult.ToString());
                tempResult.Clear();
            }
            return results;
            
        }

        public IList<string> PrintWinners(IList<EngineTermWinner> engineTermWinners)
        {
            if (engineTermWinners == null || engineTermWinners.Count == 0)
                throw new ArgumentException("The parameter is invalid", nameof(engineTermWinners));

            List<string> results = new List<string>();
            StringBuilder tempResult = new StringBuilder();

            foreach( EngineTermWinner winner in engineTermWinners)
            {
                tempResult.Append(winner.EngineName + WINNER_MESSAGE + winner.Term);
                results.Add(tempResult.ToString());
                tempResult.Clear();
            }

            return results;

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
