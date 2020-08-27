using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;
using Cignium.SearchFight.Core.Models;
using Cignium.SearchFight.Core.Interfaces;
using Cignium.SearchFight.Core.Implementation;

namespace Cignium.SearchFight.Test.Core
{
    [TestFixture]
    public class SearchManagerTest
    {

        private ISearchManager _searchManager;

        [SetUp]
        public void Setup()
        {
            _searchManager = new SearchManager();
        }

        [TearDown]
        public void Teardown()
        {
            _searchManager = null;
        }

        [Test]
        public void GetSearchEngineResults_Null_ArgumentException()
        {
            List<string> terms = null;
            Assert.ThrowsAsync<ArgumentException>(() => _searchManager.GetSearchEngineResults(terms));
        }

        [Test]
        public void GetSearchEngineResults_Empty_ArgumentException()
        {
            List<string> terms = new List<string>();
            Assert.ThrowsAsync<ArgumentException>( () => _searchManager.GetSearchEngineResults(terms));
        }

        [Test]
        public async Task GetSearchEngineResults_Success()
        {
            List<string> terms = new List<string>
            {
                ".net", "java", "net", ",java"
            };

            ContainerSearch containerSearch = await _searchManager.GetSearchEngineResults(terms);
            Assert.IsNotNull(containerSearch);
            Assert.IsNotEmpty(containerSearch.termDictionary);

        }
    }
}
