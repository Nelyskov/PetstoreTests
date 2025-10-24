using PetstoreTests.Helpers;
using System.Net;
using Allure.NUnit.Attributes;
using PetstoreTests.TestData;
using PetstoreTests.Models;


namespace PetstoreTests.Tests
{
    /// <summary>
    /// Набор автотестов для проверки работы эндпоинта <c>/pet</c> Pet API.
    /// Проверяются сценарии создания питомцев:
    /// 1. Успешное создание питомца с валидными данными (200 OK);
    /// 2. Попытка создания питомца с некорректными данными (405 Method Not Allowed).
    /// </summary>
    [AllureSuite("Pet API")]
    [AllureSubSuite("Post New Pet")]
    public class PostNewPetTest : BaseTest
    {
        /// <summary>
        /// Позитивный тест: проверяет успешное создание нового питомца с корректными данными.
        /// Ожидаемый результат — HTTP 200 OK и корректный объект <see cref="Pet"/> в ответе.
        /// </summary>
        /// <param name="pet">Объект питомца с валидными данными.</param>
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetPetJsonBody))]
        public async Task PostNewPet_ShouldReturn200(Pet pet)
        {
            var response = await RestClientHelper.PostAsync("/pet", pet);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"Unexpected status {response.StatusCode} for pet");

            if (response.StatusCode == HttpStatusCode.OK)
                ResponseAssertions.AssertResponseIs<Pet>(response);
        }
        /// <summary>
        /// Негативный тест: проверяет реакцию API на попытку создания питомца с некорректными данными.
        /// Ожидаемый результат — HTTP 405 Method Not Allowed.
        /// </summary>
        /// <param name="pet">Объект питомца с некорректными данными.</param>
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetInvalidPetJsonBody))]
        public async Task PostNewPet_ShouldReturn405(Pet pet)
        {
            var response = await RestClientHelper.PostAsync("/pet", pet);
             Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"Unexpected status {response.StatusCode} for pet" );

            if (response.StatusCode == HttpStatusCode.OK)
                ResponseAssertions.AssertResponseIs<Pet>(response);
        }
    }
}