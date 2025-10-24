using PetstoreTests.Helpers;
using System.Net;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using PetstoreTests.TestData;
using PetstoreTests.Models;
using Microsoft.CodeAnalysis;

namespace PetstoreTests.Tests
{
    /// <summary>
    /// Набор автотестов для проверки работы эндпоинта /pet/{petId}/uploadImage Pet API.
    /// Проверяется сценарий загрузки изображения питомца:
    /// 1. Успешная загрузка изображения (200 OK).
    /// </summary>
    [AllureSuite("Pet API")]
    [AllureSubSuite("Upload Image")]
    public class PostUploadImage : BaseTest
    {
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.PostUploadImageToPet))]
        public async Task PostUpdatePet_ShouldReturn200(UploadFileObjectToPet uploadFile)
        {
            var response = await RestClientHelper.PostUploadPetImageAsync(uploadFile.Id, uploadFile.FilePath, uploadFile.ResponsedParametrs);
            ResponseAssertions.AssertApiResponse(response, 200);
        }
    }
}