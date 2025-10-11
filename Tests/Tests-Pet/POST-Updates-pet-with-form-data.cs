using PetstoreTests.Helpers;
using System.Net;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using PetstoreTests.TestData;
using PetstoreTests.Models;

namespace PetstoreTests.Tests
{
    [AllureSuite("Pet API")]
    [AllureSubSuite("Update Pet with Form Data")]
    public class PostUpdatePetWithFormData : BaseTest
    {

        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.PostPetFormToUpdate))]
        public async Task PostUpdatePet_ShouldReturn200(JsonBodyToUpdatePet jsonBodyToUpdatePet)
        {
            var response = await RestClientHelper.PostAsync($"/pet/{jsonBodyToUpdatePet.Id}", jsonBodyToUpdatePet);
            ResponseAssertions.AssertApiResponse(response, 200);
        }

        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.PostPetFormToUpdate))]
        public async Task PostUpdatePet_ShouldReturn404(JsonBodyToUpdatePet jsonBodyToUpdatePet)
        {
            var response = await RestClientHelper.PostAsync($"/pet/{jsonBodyToUpdatePet.Id}", jsonBodyToUpdatePet);
            ResponseAssertions.AssertApiResponse(response, 404);
        }
        
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.PostPetFormToUpdate))]
        public async Task PostUpdatePet_ShouldReturn405(JsonBodyToUpdatePet jsonBodyToUpdatePet)
        {
            var response = await RestClientHelper.PostAsync($"/pet/{jsonBodyToUpdatePet.Id}", jsonBodyToUpdatePet);
            ResponseAssertions.AssertApiResponse(response, 405);
        }
    }
}