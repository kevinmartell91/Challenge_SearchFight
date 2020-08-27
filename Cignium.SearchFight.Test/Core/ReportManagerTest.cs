using System;
using NUnit.Framework;
using System.Collections.Generic;
using Cignium.SearchFight.Core;
using Cignium.SearchFight.Core.Models;
using Cignium.SearchFight.Core.Interfaces;
using Cignium.SearchFight.Core.Implementation;

namespace Cignium.SearchFight.Test.Core
{
    [TestFixture]
    public class ReportManagerTest
    {
        private IReportManager _reportManager;

        public ReportManagerTest()
        {
            _reportManager = new ReportManager();

        }

        #region PrintSearchResults Method Test cases

        [Test]
        public void PrintSearchResults_Null_ArgumentException()
        {
            ContainerSearch containerSearch = null;

            Assert.Throws<ArgumentException>(()=> _reportManager.PrintSearchResults(containerSearch));
        }

        [Test]
        public void PrintSearchResults_Empty_ArgumentException()
        {
            ContainerSearch containerSearch = new ContainerSearch();

            Assert.Throws<ArgumentException>(() => _reportManager.PrintSearchResults(containerSearch));
        }

        [Test]
        public void PrintSearchResults_Success()
        {
            ContainerSearch containerSearch = GetContainerSearchMockData();

            IList<string> searchResultReport = _reportManager.PrintSearchResults(containerSearch);

            Assert.NotNull(searchResultReport);
            Assert.AreNotEqual(0, searchResultReport.Count);

        }

        #endregion

        #region PrintWinners Methods test cases

        [Test]
        public void PrintWinners_Null_ArgumentException()
        {
            IList<EngineTermWinner> engineWinners = null;

            Assert.Throws<ArgumentException>(() => _reportManager.PrintWinners(engineWinners));
        }

        [Test]
        public void PrintWinners_Empty_ArgumentException()
        {
            IList<EngineTermWinner> engineWinners = new List<EngineTermWinner>();

            Assert.Throws<ArgumentException>(() => _reportManager.PrintWinners(engineWinners));
        }

        [Test]
        public void PrintWinners_Success()
        {
            IList<EngineTermWinner> engineWinners = GetEngineTermWinnersMockData();

            Assert.NotNull(engineWinners);
            Assert.IsNotEmpty(engineWinners);
            Assert.AreNotEqual(0, engineWinners.Count);

        }

        #endregion



        #region PrintTotalWinner Method Test cases

        [Test]
        public void PrintTotalWinner_Null_ArgumentException()
        {
            EngineTermWinner totalWinner = null;
            Assert.Throws<ArgumentException>(() => _reportManager.PrintTotalWinner(totalWinner));
        }

        [Test]
        public void PrintTotalWinner_Success()
        {
            EngineTermWinner totalWinner = GetTotalWinnerMockData();
            string totalWinnerReport = _reportManager.PrintTotalWinner(totalWinner);

            Assert.IsNotNull(totalWinnerReport);
            Assert.IsNotEmpty(totalWinnerReport);

        }

        #endregion

        #region Mockup data Methods

        private ContainerSearch GetContainerSearchMockData()
        {
            ContainerSearch containerSearch = new ContainerSearch
            {
                termDictionary = new Dictionary<string, List<Search>>
                {
                    { ".net", new List<Search>
                        {
                            new Search { EngineName = "Google", Term = ".net" ,TotalQueryResults = 99987543876L },
                            new Search { EngineName = "Bing", Term = ".net" ,TotalQueryResults = 865464876L },
                            new Search { EngineName = "Aol", Term = ".net" ,TotalQueryResults = 176587748L }
                        }
                    },
                    { "java", new List<Search>
                        {
                            new Search { EngineName = "Google", Term = "java" ,TotalQueryResults = 87543876L },
                            new Search { EngineName = "Bing", Term = "java" ,TotalQueryResults = 99965464876L },
                            new Search { EngineName = "Aol", Term = "java" ,TotalQueryResults = 76587748L }
                        }
                    },
                    { "java script", new List<Search>
                        {
                            new Search { EngineName = "Google", Term = "java script" ,TotalQueryResults = 7543876L },
                            new Search { EngineName = "Bing", Term = "java script" ,TotalQueryResults = 5464876L },
                            new Search { EngineName = "Aol", Term = "java script" ,TotalQueryResults = 99996587748L }
                        }
                    }
                }
            };

            return containerSearch;
        }


        private IList<EngineTermWinner> GetEngineTermWinnersMockData()
        {

            List<EngineTermWinner> mockData = new List<EngineTermWinner>
            {
                new EngineTermWinner { EngineName = "Google", Term = ".net" },
                new EngineTermWinner { EngineName = "Bing", Term = "java" },
                new EngineTermWinner { EngineName = "Aol", Term = "java script" }
            };

            return mockData;
        }

        private EngineTermWinner GetTotalWinnerMockData()
        {
            return new EngineTermWinner { EngineName = "Aol", Term = "java script" };
        }

        #endregion
    }
}
