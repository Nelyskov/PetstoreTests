using System.Net;
using System.Text.Json;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using PetstoreTests.Helpers;
using PetstoreTests.Models;
using PetstoreTests.TestData;
using RestSharp;

namespace PetstoreTests.Tests
{
    /// <summary>
    /// Набор тестов для проверки корректности получения питомцев по ID через Pet API.
    /// Покрывает как позитивные, так и негативные сценарии:
    /// 1. Получение существующего питомца — ожидается 200 OK.
    /// 2. Получение несуществующего питомца — ожидается 404 Not Found.
    /// 3. Запрос с некорректным ID — ожидается 400 Bad Request.
    /// </summary>
    [AllureSuite("Pet API")]
    [AllureSubSuite("Get Pet by ID")]
    public class GetPetByIDTests : BaseTest
    {
        /// <summary>
        /// Позитивный тест: проверяет успешное получение питомца по существующему идентификатору.
        /// Ожидаемый результат — HTTP 200 OK и корректное тело ответа с данными питомца.
        /// </summary>
        /// <param name="id">Идентификатор питомца, который существует в системе.</param>

        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetPetsId))]
        [AllureTag("Positive")]
        public async Task GetExistingPet_ShouldReturn200(long id)
        {
            var response = await RestClientHelper.GetAsync($"/pet/{id}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                $"Expected 200 OK, but got {response.StatusCode} for id={id}");

            ResponseAssertions.AssertApiResponse(response, 200);
        }

        /// <summary>
        /// Негативный тест: проверяет получение питомца по несуществующему ID.
        /// Ожидаемый результат — HTTP 404 Not Found, так как питомца с таким ID нет в базе.
        /// </summary>
        /// <param name="id">Идентификатор питомца, которого нет в системе.</param>
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetUnexistedPetsId))]
        [AllureTag("Negative")]
        public async Task GetNonExistingPet_ShouldReturn404(long id)
        {
            var response = await RestClientHelper.GetAsync($"/pet/{id}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound),
                $"Expected 404 NotFound, but got {response.StatusCode} for id={id}");
        }
        
        /// <summary>
        /// Негативный тест: проверяет поведение API при передаче некорректного ID.
        /// Например, если вместо числа передаётся строка или другой недопустимый формат.
        /// Ожидаемый результат — HTTP 400 Bad Request.
        /// </summary>
        /// <param name="id">Некорректное значение идентификатора питомца (строка, null и т.д.).</param>
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetInvalidPetsId))]
        [AllureTag("Negative")]
        public async Task GetInvalidPetId_ShouldReturn400(string id)
        {
            var response = await RestClientHelper.GetAsync($"/pet/{id}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest),
                $"Expected 400 BadRequest, but got {response.StatusCode} for id={id}");
        }
    }
}