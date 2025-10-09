using PetstoreTests.Helpers;
using System.Net;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using PetstoreTests.TestData;

namespace PetstoreTests.Tests
{
    [TestFixture]
    [AllureSuite("Pet API")]
    [AllureSubSuite("Delete Pet")]
    public class DeletePetTests : BaseTest
    {
        [Test(Description = "Delete pet by ID")]
        [AllureTag("API", "pet", "DELETE")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Nikita")]
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetPetsId))]
        public async Task DeletePetByID_ShouldReturnExpectedStatus(long id)
        {
            var response = await RestClientHelper.DeleteAsync($"/pet/{id}");

            Assert.That(
                response.StatusCode == HttpStatusCode.OK 
                || response.StatusCode == HttpStatusCode.BadRequest 
                || response.StatusCode == HttpStatusCode.NotFound,
                Is.True,
                $"Unexpected status {response.StatusCode} for id={id}"
            );
        }
    }
}
