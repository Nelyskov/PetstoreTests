using PetstoreTests.Helpers;
using Allure.NUnit.Attributes;
using PetstoreTests.TestData;


namespace PetstoreTests.Tests
{
    /// <summary>
    /// Набор автотестов для проверки работы эндпоинта <c>/pet/{petId}</c> с формой обновления Pet API.
    /// Проверяются сценарии обновления питомцев через форму:
    /// 1. Успешное обновление питомца (200 OK);
    /// 2. Попытка обновления несуществующего питомца (404 Not Found);
    /// 3. Ошибки при некорректных данных или методе (405 Method Not Allowed).
    /// </summary>
    [AllureSuite("Pet API")]
    [AllureSubSuite("Update Pet with Form Data")]
    public class PostUpdatePetWithFormData : BaseTest
    {
        /// <summary>
        /// Позитивный тест: проверяет успешное обновление питомца через форму.
        /// Ожидаемый результат — HTTP 200 OK.
        /// </summary>
        /// <param name="jsonBodyToUpdatePet">Объект с данными для обновления питомца.</param>
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.PostPetFormToUpdate))]
        public async Task PostUpdatePet_ShouldReturn200(JsonBodyToUpdatePet jsonBodyToUpdatePet)
        {
            var response = await RestClientHelper.PostAsync($"/pet/{jsonBodyToUpdatePet.Id}", jsonBodyToUpdatePet);
            ResponseAssertions.AssertApiResponse(response, 200);
        }
        
        /// <summary>
        /// Негативный тест: проверяет реакцию API при попытке обновления несуществующего питомца.
        /// Ожидаемый результат — HTTP 404 Not Found.
        /// </summary>
        /// <param name="jsonBodyToUpdatePet">Объект с данными для обновления питомца.</param>
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.PostPetFormToUpdate))]
        public async Task PostUpdatePet_ShouldReturn404(JsonBodyToUpdatePet jsonBodyToUpdatePet)
        {
            var response = await RestClientHelper.PostAsync($"/pet/{jsonBodyToUpdatePet.Id}", jsonBodyToUpdatePet);
            ResponseAssertions.AssertApiResponse(response, 404);
        }
        
        /// <summary>
        /// Негативный тест: проверяет реакцию API при некорректных данных или методе запроса.
        /// Ожидаемый результат — HTTP 405 Method Not Allowed.
        /// </summary>
        /// <param name="jsonBodyToUpdatePet">Объект с данными для обновления питомца.</param>
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.PostPetFormToUpdate))]
        public async Task PostUpdatePet_ShouldReturn405(JsonBodyToUpdatePet jsonBodyToUpdatePet)
        {
            var response = await RestClientHelper.PostAsync($"/pet/{jsonBodyToUpdatePet.Id}", jsonBodyToUpdatePet);
            ResponseAssertions.AssertApiResponse(response, 405);
        }
    }
}