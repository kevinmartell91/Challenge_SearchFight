using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Cignium.SearchFight.Services.Implementation;

namespace Cignium.SearchFight.Test.Services
{
    [TestFixture]
    public class BingSearchTest
    {
        private BingSearchEngine _bingSearchEngine;

        public BingSearchTest()
        {
            _bingSearchEngine = new BingSearchEngine();
        }

        [Test]
        public void GetTotalResultsAsync_Null_ArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(() => _bingSearchEngine.GetTotalResultsAsync(null));
        }

        [Test]
        public void GetTotalResultsAsync_Empty_ArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(() => _bingSearchEngine.GetTotalResultsAsync(string.Empty));
        }

        [Test]
        public async Task GetTotalResultsAsync_Success()
        {
            var response = await _bingSearchEngine.GetTotalResultsAsync("python");
            Assert.IsNotNull(response);
            Assert.IsInstanceOf<long>(response);
        }
    }
}
