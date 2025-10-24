using PetstoreTests.Helpers;
using PetstoreTests.Models;
using System.Net;
using PetstoreTests.TestData;

namespace PetstoreTests.Tests
{
    /// <summary>
    /// Тесты для проверки работы эндпоинта <c>/store/inventory</c> Order API.
    /// Проверяется сценарий получения информации о запасах питомцев по статусу.
    /// 1. Успешное получение данных об инвентаре (200 OK).
    /// </summary>
    public class PlaceAnOrderForPet : BaseTest
    {
        [TestCaseSource(typeof(StoreTestData), nameof(StoreTestData.GetOrderJsonBody))]
        public async Task PlaceAnOrderForPet_ShouldReturn200(Order order)
        {
            var response = await RestClientHelper.PostAsync("/store/order", order);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                $"Expected 200 OK, but got {response.StatusCode} ");
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