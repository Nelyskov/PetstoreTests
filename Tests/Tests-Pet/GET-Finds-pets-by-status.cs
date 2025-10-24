using PetstoreTests.Helpers;
using System.Net;
using Allure.NUnit.Attributes;
using PetstoreTests.TestData;
using PetstoreTests.Models;

namespace PetstoreTests.Tests
{
    /// <summary>
    /// Набор автотестов для проверки работы эндпоинта <c>/pet/findByStatus</c> Pet API.
    /// Проверяются сценарии получения питомцев по статусу:
    /// 1. Успешное получение питомцев по корректному статусу (200 OK);
    /// 2. Ошибка при передаче несуществующего или некорректного статуса (400 Bad Request).
    /// </summary>
    [AllureSuite("Pet API")]
    [AllureSubSuite("Find Pet by status")]
    public class FindPetByStatusTests : BaseTest
    {
        /// <summary>
        /// Позитивный тест: проверяет успешное получение списка питомцев по существующему статусу.
        /// Ожидаемый результат — HTTP 200 OK и корректный список объектов <see cref="Pet"/>.
        /// </summary>
        /// <param name="petStatus">Корректный статус питомца (например: "available", "pending", "sold").</param>
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetPetsStatus))]
        public async Task FindPetByStatus_ShouldReturn200(string petStatus)
        {
            var response = await RestClientHelper.GetAsync("/pet/findByStatus", ("status", petStatus));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
               $"Expected 200 OK, but got {response.StatusCode} for status={petStatus}");

            if (response.StatusCode == HttpStatusCode.OK)
                ResponseAssertions.AssertResponseIs<List<Pet>>(response);
        }
        
        /// <summary>
        /// Негативный тест: проверяет реакцию API на передачу некорректного или несуществующего статуса.
        /// Ожидаемый результат — HTTP 400 Bad Request.
        /// </summary>
        /// <param name="petStatus">Некорректное значение статуса питомца.</param>
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetPetsUnexistedStatus))]
        public async Task FindPetByStatus_ShouldReturn400(string petStatus)
        {
            var response = await RestClientHelper.GetAsync("/pet/findByStatus", ("status", petStatus));
             Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest),
                $"Expected 400 OK, but got {response.StatusCode} for status={petStatus}");

        }
    }
}