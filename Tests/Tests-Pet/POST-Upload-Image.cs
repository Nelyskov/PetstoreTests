using PetstoreTests.Helpers;
using System.Net;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using PetstoreTests.TestData;
using PetstoreTests.Models;
using Microsoft.CodeAnalysis;

namespace PetstoreTests.Tests
{
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