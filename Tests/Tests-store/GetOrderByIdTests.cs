using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using PetstoreTests.Helpers;
using PetstoreTests.Models;
using PetstoreTests.TestData;

namespace PetstoreTests.Tests
{
    public class GetOrderByIdTests : BaseTest
    {
        [TestCaseSource(typeof(StoreTestData), nameof(StoreTestData.GetOrderIds))]
        public async Task GetOrderById_ShouldReturn200_WhenOrderExists(long orderId)
        {
            var response = await RestClientHelper.GetAsync($"/store/order/{orderId}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                $"Expected 200 OK, but got {response.StatusCode}");

            ResponseAssertions.AssertApiResponse(response, 200);
        }

        [TestCaseSource(typeof(StoreTestData), nameof(StoreTestData.GetInvalidOrdersId))]
        public async Task GetOrderById_ShouldReturn400_WhenIdIsInvalid(string invalidId)
        {
            var response = await RestClientHelper.GetAsync($"/store/order/{invalidId}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest),
                $"Expected 400 BadRequest, but got {response.StatusCode}");
        }

        [TestCaseSource(typeof(StoreTestData), nameof(StoreTestData.GetUnexistedOrdersId))]
        public async Task GetOrderById_ShouldReturn404_WhenOrderNotFound(int orderId)
        {
            var response = await RestClientHelper.GetAsync($"/store/order/{orderId}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound),
                $"Expected 404 NotFound, but got {response.StatusCode}");
        }
    }
}