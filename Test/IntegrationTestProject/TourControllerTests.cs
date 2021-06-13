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
    public class TourControllerTests : IClassFixture<CommonApplicationFactory<TravelCompanyWebApi.Startup>>
    {
        private readonly HttpClient _client;
        private readonly CommonApplicationFactory<TravelCompanyWebApi.Startup> _factory;

        public TourControllerTests(CommonApplicationFactory<TravelCompanyWebApi.Startup> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetToursByClimateName_ExistClimateAndToursHaveHotels_ReturnsOkNotEmptyList()
        {
            // Arrange
            var url = "Tours/Climate/Dry";

            // Act
            var response = await _client.GetAsync(url);

            var result = JsonSerializer.Deserialize<IEnumerable<TourDTO>>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetToursByClimateName_ExistClimateAndToursHaveNoHotels_ReturnsOkEmptyList()
        {
            // Arrange
            var url = "Tours/Climate/Polar";

            // Act
            var response = await _client.GetAsync(url);

            var result = JsonSerializer.Deserialize<IEnumerable<TourDTO>>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetToursByClimateName_ExistClimateAndNoHotelsForCities_ReturnsNotFoundNoHotelsMessage()
        {
            // Arrange
            var url = "Tours/Climate/Tropical";

            // Act
            var response = await _client.GetAsync(url);

            var result = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal("No hotels was found for cities with this climate.", result);
        }

        [Fact]
        public async Task GetToursByClimateName_ExistClimateAndNoCitiesForClimate_ReturnsNotFoundNoCitiesMessage()
        {
            // Arrange
            var url = "Tours/Climate/Mild";

            // Act
            var response = await _client.GetAsync(url);

            var result = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal("No cities was found for this climate.", result);
        }

        [Fact]
        public async Task GetToursByClimateName_NoExistClimate_ReturnsNotFoundNoClimateMessage()
        {
            // Arrange
            var url = "Tours/Climate/Climate";

            // Act
            var response = await _client.GetAsync(url);

            var result = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal("There is no climate with this name.", result);
        }
    }
}
