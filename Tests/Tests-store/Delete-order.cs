using PetstoreTests.Helpers;
using System.Net;
using Allure.NUnit.Attributes;
using PetstoreTests.TestData;


namespace PetstoreTests.Tests
{
    [AllureSuite("Order API")]
    [AllureSubSuite("Delete Order")]
    public class DeleteOrderTests : BaseTest
    {

        [TestCaseSource(typeof(StoreTestData), nameof(StoreTestData.GetOrderIds))]
        [AllureTag("Positive")]
        public async Task DeleteExistingOrder_ShouldReturn200(long id)
        {
            var response = await RestClientHelper.DeleteAsync($"/store/order/{id}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                $"Expected 200 OK, but got {response.StatusCode} for id={id}");

            ResponseAssertions.AssertApiResponse(response, 200);
        }

        [TestCaseSource(typeof(StoreTestData), nameof(StoreTestData.GetUnexistedOrdersId))]
        [AllureTag("Negative")]
        public async Task DeleteNonExistingOrder_ShouldReturn404(long id)
        {
            var response = await RestClientHelper.DeleteAsync($"/store/order/{id}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound),
                $"Expected 404 NotFound, but got {response.StatusCode} for id={id}");
        }

        [TestCaseSource(typeof(StoreTestData), nameof(StoreTestData.GetInvalidOrdersId))]
        [AllureTag("Negative")]
        public async Task DeleteInvalidOrderId_ShouldReturn400(string id)
        {
            var response = await RestClientHelper.DeleteAsync($"/store/order/{id}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest),
                $"Expected 400 BadRequest, but got {response.StatusCode} for id={id}");
        }
    }
}
