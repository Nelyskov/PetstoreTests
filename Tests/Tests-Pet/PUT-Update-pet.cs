using PetstoreTests.Helpers;
using System.Net;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using PetstoreTests.TestData;
using PetstoreTests.Models;
using RestSharp;


namespace PetstoreTests.Tests
{
    /// <summary>
    /// Набор автотестов для проверки работы эндпоинта <c>/pet</c> методом PUT Pet API.
    /// Проверяется сценарий обновления существующего питомца:
    /// 1. Успешное обновление питомца (200 OK);
    /// 2. Ошибки при некорректных данных, несуществующем питомце или некорректном методе (400, 404, 405).
    /// </summary>
    [AllureSuite("Pet API")]
    [AllureSubSuite("PUT Update Existing Pet")]
    public class UpdateAnExistingPet : BaseTest
    {
        /// <summary>
        /// Тест проверяет обновление питомца через PUT /pet.
        /// Ожидаемые коды ответа:
        /// - 200 OK — успешное обновление;
        /// - 400 Bad Request — некорректные данные;
        /// - 404 Not Found — питомец не найден;
        /// - 405 Method Not Allowed — метод недопустим.
        /// При успешном обновлении выполняется проверка структуры ответа <see cref="Pet"/>.
        /// </summary>
        /// <param name="pet">Объект питомца с данными для обновления.</param>
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetPetJsonBody))]
        public async Task PutUpdatePet_ShouldReturnExpectedStatus(Pet pet)
        {
            var response = await RestClientHelper.PutAsync("/pet", pet);
            Assert.That(
                response.StatusCode == HttpStatusCode.OK
                || response.StatusCode == HttpStatusCode.BadRequest
                || response.StatusCode == HttpStatusCode.NotFound
                || response.StatusCode == HttpStatusCode.MethodNotAllowed,
                Is.True,
                $"Unexpected API response code {response.StatusCode}."
            );

            if (response.StatusCode == HttpStatusCode.OK)
                ResponseAssertions.AssertResponseIs<Pet>(response);
        }

    }
}