using System;
using System.Collections.Generic;
using Cignium.SearchFight.Core.Models;

namespace Cignium.SearchFight.Core.Interfaces
{
    public interface IReportManager
    {
        /// <summary>
        /// Show in console the general search results of the search fight.
        /// </summary>
        /// <param name="containerSearch"></param> Holds the general search
        /// results of the search fight.
        /// <returns> List of strings with the search results by a
        /// given term plus all the search engines that queried it</returns>
        IList<string> PrintSearchResults(ContainerSearch containerSearch);

        /// <summary>
        /// Show in the console the search engine winners by terms of 
        /// search the highest search results.
        /// </summary>
        /// <param name="engineTermWinners"></param>
        /// <returns> A list of winners  </returns>
        IList<string> PrintWinners(IList<EngineTermWinner> engineTermWinners);


        /// <summary>
        /// Show in the console the total winner from the search fight.
        /// </summary>
        /// <param name="totalWinner"></param> An object that holds the
        /// total winner.
        /// <returns> A string with total winner's data </returns>
        string PrintTotalWinner(EngineTermWinner totalWinner);

    }
}
