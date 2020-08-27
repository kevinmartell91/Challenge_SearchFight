using System.Threading.Tasks;
using System.Collections.Generic;
using Cignium.SearchFight.Core.Implementation;
using Cignium.SearchFight.Core.Models;
using Cignium.SearchFight.Core.Interfaces;
using System;

namespace Cignium.SearchFight.Core
{
    public static class SearchFightCore
    {
        public static List<string> Reports { get; private set; }

        static ISearchManager SearchManager;
        static IWinnerManager WinnerManager;
        static IReportManager ReportManager;

        static SearchFightCore()
        {
            SearchManager = new SearchManager();
            WinnerManager = new WinnerManager();
            ReportManager = new ReportManager();

            Reports = new List<string>();
        }

        public static async Task StartAsync(IList<string> terms)
        {
            ContainerSearch searchDataContainer = await SearchManager.GetSearchEngineResults(terms);
            Reports.AddRange(ReportManager.PrintSearchResults(searchDataContainer));

            List<EngineTermWinner> SearchEngineWinners = WinnerManager.GetEngineWinners(searchDataContainer);
            Reports.AddRange(ReportManager.PrintWinners(SearchEngineWinners));

            EngineTermWinner totalwinner = WinnerManager.GetTotalWinner(searchDataContainer);
            Reports.Add(ReportManager.PrintTotalWinner(totalwinner));
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
        }
    }
}
