using System;
using System.Collections.Generic;
using Cignium.SearchFight.Core.Models;

namespace Cignium.SearchFight.Core.Interfaces
{
    public interface IWinnerManager
    {

        /// <summary>
        /// A list engine winners from the serach fight.
        /// </summary>
        /// <param name="containerSearch"></param> Holds the general information
        /// of the search fight in terms of search results.
        /// <returns> List of engines with their highest search results</returns>
        List<EngineTermWinner> GetEngineWinners(ContainerSearch containerSearch);

        /// <summary>
        /// Retrieve the total winner of the search fight
        /// </summary>
        /// <param name="containerSearch"></param> Holds the general information
        /// of the search fight in terms of search results.
        /// <returns> Total winner of the search fight .</returns>
        EngineTermWinner GetTotalWinner(ContainerSearch containerSearch);
    }
}
