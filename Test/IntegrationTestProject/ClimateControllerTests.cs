using IntegrationTestProject.ApplicationFactory;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.DTO;
using Xunit;

namespace IntegrationTestProject
{
    public class ClimateControllerTests : IClassFixture<CommonApplicationFactory<TravelCompanyWebApi.Startup>>
    {
        private readonly HttpClient _client;
        private readonly CommonApplicationFactory<TravelCompanyWebApi.Startup> _factory;

        public ClimateControllerTests(CommonApplicationFactory<TravelCompanyWebApi.Startup> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task ClientController_GetAll_ReturnsOK()
        {
            // Arrange
            var url = "Climates";

            // Act
            var response = await _client.GetAsync(url);

            var result = JsonSerializer.Deserialize<IEnumerable<ClimateDTO>>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task ClientController_GetByExistentId_ReturnsOk()
        {
            // Arrange
            var url = "Climates/1";

            // Act
            var response = await _client.GetAsync(url);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ClientController_GetByNonExistentId_ReturnsNoContent()
        {
            // Arrange
            var url = "Climates/0";

            // Act
            var response = await _client.GetAsync(url);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task ClientController_PostValidClimate_ReturnsOk()
        {
            // Arrange
            var url = "Climates/";
            var content = new StringContent(JsonSerializer.Serialize(new ClimateDTO { Name = "Mild"}), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync(url, content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ClientController_PostInvalidClimate_ReturnsBadRequest()
        {
            // Arrange
            var url = "Climates/";
            var content = new StringContent(JsonSerializer.Serialize(new ClimateDTO ()), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync(url, content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
