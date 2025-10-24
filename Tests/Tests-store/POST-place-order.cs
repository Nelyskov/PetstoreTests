using PetstoreTests.Helpers;
using PetstoreTests.Models;
using System.Net;
using PetstoreTests.TestData;

namespace PetstoreTests.Tests
{
    public class PlaceAnOrderForPet : BaseTest
    {
        [TestCaseSource(typeof(StoreTestData), nameof(StoreTestData.GetOrderJsonBody))]
        public async Task PlaceAnOrderForPet_ShouldReturn200(Order order)
        {
            var response = await RestClientHelper.PostAsync("/store/order", order);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                $"Expected 400 OK, but got {response.StatusCode} ");
        }
        [TestCaseSource(typeof(StoreTestData), nameof(StoreTestData.GetOrderJsonBody))]
        public async Task PlaceAnOrderForPet_ShouldReturn400_ResponseInvalidBody(Order order)
        {
            var response = await RestClientHelper.PostAsync("/store/order", new { /* order details */ });
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest),
                $"Expected 400 OK, but got {response.StatusCode} ");
        }
    }
}