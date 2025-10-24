using PetstoreTests.Helpers;
using System.Net;
using Allure.NUnit.Attributes;
using PetstoreTests.TestData;


namespace PetstoreTests.Tests
{
    /// <summary>
    /// Набор автотестов для проверки работы эндпоинта <c>/store/order/{orderId}</c> Order API.
    /// Проверяются сценарии удаления заказов:
    /// 1. Успешное удаление существующего заказа (200 OK);
    /// 2. Попытка удаления несуществующего заказа (404 Not Found);
    /// 3. Попытка удаления с некорректным идентификатором (400 Bad Request).
    /// </summary>
    [AllureSuite("Order API")]
    [AllureSubSuite("Delete Order")]
    public class DeleteOrderTests : BaseTest
    {
        /// <summary>
        /// Позитивный тест: проверяет успешное удаление существующего заказа.
        /// Ожидаемый результат — HTTP 200 OK и корректный ответ API.
        /// </summary>
        /// <param name="id">Идентификатор существующего заказа.</param>
        [TestCaseSource(typeof(StoreTestData), nameof(StoreTestData.GetOrderIds))]
        [AllureTag("Positive")]
        public async Task DeleteExistingOrder_ShouldReturn200(long id)
        {
            var response = await RestClientHelper.DeleteAsync($"/store/order/{id}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                $"Expected 200 OK, but got {response.StatusCode} for id={id}");

            ResponseAssertions.AssertApiResponse(response, 200);
        }
        /// <summary>
        /// Негативный тест: проверяет реакцию API при попытке удалить несуществующий заказ.
        /// Ожидаемый результат — HTTP 404 Not Found.
        /// </summary>
        /// <param name="id">Идентификатор несуществующего заказа.</param>
        [TestCaseSource(typeof(StoreTestData), nameof(StoreTestData.GetUnexistedOrdersId))]
        [AllureTag("Negative")]
        public async Task DeleteNonExistingOrder_ShouldReturn404(long id)
        {
            var response = await RestClientHelper.DeleteAsync($"/store/order/{id}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound),
                $"Expected 404 NotFound, but got {response.StatusCode} for id={id}");
        }
        /// <summary>
        /// Негативный тест: проверяет реакцию API при передаче некорректного идентификатора заказа.
        /// Ожидаемый результат — HTTP 400 Bad Request.
        /// </summary>
        /// <param name="id">Некорректный идентификатор заказа (нечисловое значение или неподходящий формат).</param>
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
