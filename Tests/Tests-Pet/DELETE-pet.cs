using PetstoreTests.Helpers;
using System.Net;
using Allure.NUnit.Attributes;
using PetstoreTests.TestData;


namespace PetstoreTests.Tests
{
    /// <summary>
    /// Набор тестов для проверки корректности удаления питомцев через Pet API.
    /// Проверяются три основных сценария:
    /// 1. Удаление существующего питомца (ожидается 200 OK)
    /// 2. Удаление несуществующего питомца (ожидается 404 Not Found)
    /// 3. Удаление с некорректным ID (ожидается 400 Bad Request)
    /// </summary>
    [AllureSuite("Pet API")]
    [AllureSubSuite("Delete Pet")]
    
    public class DeletePetTests : BaseTest
    {
        /// <summary>
        /// Позитивный тест: проверяет успешное удаление питомца по существующему ID.
        /// Ожидаемый результат — статус код 200 OK и корректное тело ответа.
        /// </summary>
        /// <param name="id">Идентификатор питомца, который существует в системе.</param>

        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetPetsId))]
        [AllureTag("Positive")]
        public async Task DeleteExistingPet_ShouldReturn200(long id)
        {
            var response = await RestClientHelper.DeleteAsync($"/pet/{id}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                $"Expected 200 OK, but got {response.StatusCode} for id={id}");

            ResponseAssertions.AssertApiResponse(response, 200);
        }

        /// <summary>
        /// Негативный тест: проверяет удаление питомца по несуществующему ID.
        /// Ожидаемый результат — статус код 404 Not Found.
        /// </summary>
        /// <param name="id">Идентификатор питомца, которого нет в базе данных.</param>
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetUnexistedPetsId))]
        [AllureTag("Negative")]
        public async Task DeleteNonExistingPet_ShouldReturn404(long id)
        {
            var response = await RestClientHelper.DeleteAsync($"/pet/{id}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound),
                $"Expected 404 NotFound, but got {response.StatusCode} for id={id}");
        }
        /// <summary>
        /// Негативный тест: проверяет удаление питомца с некорректным идентификатором.
        /// Например, передача строки вместо числа.
        /// Ожидаемый результат — статус код 400 Bad Request.
        /// </summary>
        /// <param name="id">Некорректное значение идентификатора питомца (строка, null и т.д.).</param>
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetInvalidPetsId))]
        [AllureTag("Negative")]
        public async Task DeleteInvalidPetId_ShouldReturn400(string id)
        {
            var response = await RestClientHelper.DeleteAsync($"/pet/{id}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest),
                $"Expected 400 BadRequest, but got {response.StatusCode} for id={id}");
        }
    }
}
