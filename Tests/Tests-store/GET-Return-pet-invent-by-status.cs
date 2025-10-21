using PetstoreTests.Helpers;
using System.Net;

namespace PetstoreTests.Tests
{
    public class ReturnPetInventoriesByStatus : BaseTest
    {
        public async Task ReturnInventoriesByStatus_ShouldReturn200_ResnoseBodyAndHeaders()
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