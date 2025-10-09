using NUnit.Framework;
using PetstoreTests.Helpers;
using System.Net;
using System.Threading.Tasks;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;

namespace PetstoreTests.Tests
{
    [AllureSuite("Pet Test")]
    public class PetTests : BaseTest
    {
        private ApiClient _apiClient;
        [SetUp]
        public void Init()
        {
            _apiClient = new ApiClient();
        }

        [Test(Description = "Get pet by ID")]
        [AllureTag("API")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Nikita")]
        public async Task GetPetById_ShouldReturnPet()
        {
            var response = await _apiClient.GetAsync("pet/1");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var content = await response.Content.ReadAsStringAsync();
            Assert.That(content.Contains(@"""id"":1"), "Response does not contain id=1");
        }

        [Test(Description = "Delete pet by ID")]
        [AllureTag("API")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Nikita")]
        public async Task DeletePetByID_ShouldReturnSuccess()
        {
            var response = await _apiClient.DeleteAsync("pet/1");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}