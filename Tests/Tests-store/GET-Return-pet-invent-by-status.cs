using PetstoreTests.Helpers;
using System.Net;

namespace PetstoreTests.Tests
{
    /// <summary>
    /// Тесты для проверки работы эндпоинта /store/inventory Order API.
    /// Проверяется сценарий получения информации о запасах питомцев по статусу.
    /// 1. Успешное получение данных об инвентаре (200 OK).
    /// </summary>
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