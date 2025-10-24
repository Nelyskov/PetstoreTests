using PetstoreTests.Helpers;
using System.Net;

namespace PetstoreTests.Tests
{
    public class ReturnPetInventoriesByStatus : BaseTest
    {
        [Test]
        public async Task ReturnInventories_ShouldReturn200()
        {
            var response = await RestClientHelper.GetAsync("/store/inventory");
            Assert.That(
                response.StatusCode == HttpStatusCode.OK,
                Is.True,
                $"Unexpected status {response.StatusCode} for inventory"
            );

            
        }
    }
}