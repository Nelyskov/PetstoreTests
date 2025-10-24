using System.Net;
using PetstoreTests.Helpers;
using PetstoreTests.TestData;

namespace PetstoreTests.Tests
{    
    /// <summary>
    /// Набор автотестов для проверки работы эндпоинта /store/order/{orderId} Order API.
    /// Проверяются сценарии получения заказа по идентификатору:
    /// 1. Успешное получение существующего заказа (200 OK);
    /// 2. Попытка получения с некорректным идентификатором (400 Bad Request);
    /// 3. Попытка получения несуществующего заказа (404 Not Found).
    /// </summary>
    public class GetOrderByIdTests : BaseTest
    {
        /// <summary>
        /// Позитивный тест: проверяет успешное получение заказа по существующему идентификатору.
        /// Ожидаемый результат — HTTP 200 OK и корректный ответ API.
        /// </summary>
        /// <param name="orderId">Идентификатор существующего заказа.</param>
        [TestCaseSource(typeof(StoreTestData), nameof(StoreTestData.GetOrderIds))]
        public async Task GetOrderById_ShouldReturn200_WhenOrderExists(int orderId)
        {
            var response = await RestClientHelper.GetAsync($"/store/order/{orderId}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                $"Expected 200 OK, but got {response.StatusCode}");

            ResponseAssertions.AssertApiResponse(response, 200);
        }
        /// <summary>
        /// Негативный тест: проверяет реакцию API на некорректный идентификатор заказа.
        /// Ожидаемый результат — HTTP 400 Bad Request.
        /// </summary>
        /// <param name="invalidId">Некорректный идентификатор заказа.</param>
        [TestCaseSource(typeof(StoreTestData), nameof(StoreTestData.GetInvalidOrdersId))]
        public async Task GetOrderById_ShouldReturn400_WhenIdIsInvalid(string invalidId)
        {
            var response = await RestClientHelper.GetAsync($"/store/order/{invalidId}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest),
                $"Expected 400 BadRequest, but got {response.StatusCode}");
        }
        /// <summary>
        /// Негативный тест: проверяет реакцию API при попытке получить несуществующий заказ.
        /// Ожидаемый результат — HTTP 404 Not Found.
        /// </summary>
        /// <param name="orderId">Идентификатор несуществующего заказа.</param>
        [TestCaseSource(typeof(StoreTestData), nameof(StoreTestData.GetUnexistedOrdersId))]
        public async Task GetOrderById_ShouldReturn404_WhenOrderNotFound(int orderId)
        {
            var response = await RestClientHelper.GetAsync($"/store/order/{orderId}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound),
                $"Expected 404 NotFound, but got {response.StatusCode}");
        }
    }
}