using System;
using System.Collections.Generic;
using Cignium.SearchFight.Core.Models;

namespace Cignium.SearchFight.Core.Interfaces
{
    public interface IReportManager
    {

        IList<string> PrintSearchResults(ContainerSearch containerSearch);

        IList<string> PrintWinners(IList<EngineTermWinner> engineTermWinners);

        string PrintTotalWinner(EngineTermWinner totalWinner);

    }
}
