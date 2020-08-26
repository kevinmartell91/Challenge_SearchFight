using System;
using System.Collections.Generic;
using Cignium.SearchFight.Core.Models;

namespace Cignium.SearchFight.Core.Interfaces
{
    public interface IWinnerManager
    {

        /// <summary>
        /// Retrive a
        /// </summary>
        /// <param name="containerSearch"></param>
        /// <returns></returns>
        List<EngineTermWinner> GetEngineWinners(ContainerSearch containerSearch);

      
        EngineTermWinner GetTotalWinner(ContainerSearch containerSearch);
    }
}
