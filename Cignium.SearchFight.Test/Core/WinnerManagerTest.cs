using System;
using System.Collections.Generic;
using NUnit.Framework;
using Cignium.SearchFight.Core;
using Cignium.SearchFight.Core.Models;
using Cignium.SearchFight.Core.Interfaces;
using Cignium.SearchFight.Core.Implementation;

namespace Cignium.SearchFight.Test.Core
{
    [TestFixture]
    public class WinnerManagerTest
    {
        private IWinnerManager _winnerManager;

        public WinnerManagerTest()
        {
            _winnerManager = new WinnerManager();
        }

        #region GetEngineWinners method test cases

        [Test]
        public void GetEngineWinners_Null_ArgumentException()
        {
            ContainerSearch containerSearch = null;
            Assert.Throws<ArgumentException>(()=> _winnerManager.GetEngineWinners(containerSearch));
        }

        [Test]
        public void GetEngineWinners_Empty_ArgumentException()
        {
            ContainerSearch containerSearch = new ContainerSearch();

            Assert.Throws<ArgumentException>(() => _winnerManager.GetEngineWinners(containerSearch));
        }

        [Test]
        public void GetEngineWinners_Success()
        {
            List<EngineTermWinner> engineWinners = _winnerManager.GetEngineWinners(GetContainerSearchMockData());
            Assert.IsNotNull(engineWinners);
            Assert.IsNotEmpty(engineWinners);

            Assert.AreEqual(".net", engineWinners[0].Term);
            Assert.AreEqual("Google", engineWinners[0].EngineName);

            Assert.AreEqual("java", engineWinners[1].Term);
            Assert.AreEqual("Bing", engineWinners[1].EngineName);

            Assert.AreEqual("java script", engineWinners[2].Term);
            Assert.AreEqual("Aol", engineWinners[2].EngineName);

        }
        #endregion

        #region GetTotalWinner Method test cases

        [Test]
        public void GetTotalWinner_Null_ArgumentException()
        {
            ContainerSearch containerSearch = null;
            Assert.Throws<ArgumentException>(() => _winnerManager.GetTotalWinner(containerSearch));
        }

        [Test]
        public void GetTotalWinner_Empty_ArgumentException()
        {
            ContainerSearch containerSearch = new ContainerSearch();

            Assert.Throws<ArgumentException>(() => _winnerManager.GetTotalWinner(containerSearch));
        }

        [Test]
        public void GetTotalWinner_Success()
        {
            EngineTermWinner totalWinner = _winnerManager.GetTotalWinner(GetContainerSearchMockData());
            Assert.IsNotNull(totalWinner);
            Assert.IsNotEmpty(totalWinner.EngineName);
            Assert.IsNotEmpty(totalWinner.Term);

            Assert.AreEqual("Aol", totalWinner.EngineName);
            Assert.AreEqual("java script", totalWinner.Term);

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

        #endregion
    }
}
