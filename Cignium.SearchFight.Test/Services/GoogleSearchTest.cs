using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Cignium.SearchFight.Services.Implementation;
using Cignium.SearchFight.Services.Interfaces;

namespace Cignium.SearchFight.Test.Services
{
    [TestFixture]
    public class GoogleSearchTest
    {
        private ISearchEngine _searchEngine;

        public GoogleSearchTest()
        {
            _searchEngine = new GoogleSearchEngine();
        }

        [Test]
        public void GetTotalResultsAsync_Null_ArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>( () => _searchEngine.GetTotalResultsAsync(null));
        }

        [Test]
        public void GetTotalResultsAsync_Empty_ArgumenException()
        {
            Assert.ThrowsAsync<ArgumentException>( () => _searchEngine.GetTotalResultsAsync(string.Empty));
        }

        [Test]
        public async Task GetTotalResultsAsync_Success()
        {
            var response = await _searchEngine.GetTotalResultsAsync("python");
            Assert.IsNotNull(response);
            Assert.IsInstanceOf<long>(response);
        }
    }
}
