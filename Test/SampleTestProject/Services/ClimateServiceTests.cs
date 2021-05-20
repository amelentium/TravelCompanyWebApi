using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Service;
using UnitTestProject.Mocks;
using Xunit;

namespace UnitTestProject.Services
{
    public class ClimateServiceTests
    {
        [Fact]
        public async Task ClimateService_GetAllClimates_ReturnsIEnumerableClimates()
        {
            // Arrange
            var mockClimates = new List<Climate> { new Climate(), };

            var mockClimateRepository = await new MockClimateRepository().MockGetAll(mockClimates);

            var mockUnitOfWork = new MockUnitOfWork().MockGetClimateRepository(mockClimateRepository.Object);

            var climateService = new ClimateService(mockUnitOfWork.Object);

            // Act
            var climate = await climateService.GetClimates();

            // Assert
            Assert.NotNull(climate);
            mockUnitOfWork.VerifyGetClimateRepository(Times.Once());
            mockClimateRepository.VerifyGetAll(Times.Once());
        }

        [Fact]
        public async Task ClimateService_GetAllClimates_ReturnsNull()
        {
            // Arrange
            var mockClimateRepository = await new MockClimateRepository().MockGetAll(null);

            var mockUnitOfWork = new MockUnitOfWork().MockGetClimateRepository(mockClimateRepository.Object);

            var climateService = new ClimateService(mockUnitOfWork.Object);

            // Act
            var climate = await climateService.GetClimates();

            // Assert
            Assert.Null(climate);
            mockUnitOfWork.VerifyGetClimateRepository(Times.Once());
            mockClimateRepository.VerifyGetAll(Times.Once());
        }

        [Fact]
        public async Task ClimateService_GetClimateByExistentId_ReturnsClimate()
        {
            // Arrange
            var mockClimate = new Climate();

            var mockClimateRepository = await new MockClimateRepository().MockGetById(mockClimate);

            var mockUnitOfWork = new MockUnitOfWork().MockGetClimateRepository(mockClimateRepository.Object);

            var climateService = new ClimateService(mockUnitOfWork.Object);

            // Act
            var climate = await climateService.GetClimateById(1);

            // Assert
            Assert.NotNull(climate);
            mockUnitOfWork.VerifyGetClimateRepository(Times.Once());
            mockClimateRepository.VerifyGetById(Times.Once());
        }

        [Fact]
        public async Task ClimateService_GetClimateByNonExistentId_ReturnsNull()
        {
            // Arrange
            var mockClimateRepository = await new MockClimateRepository().MockGetById(null);

            var mockUnitOfWork = new MockUnitOfWork().MockGetClimateRepository(mockClimateRepository.Object);

            var climateService = new ClimateService(mockUnitOfWork.Object);

            // Act
            var climate = await climateService.GetClimateById(1);

            // Assert
            Assert.Null(climate);
            mockUnitOfWork.VerifyGetClimateRepository(Times.Once());
            mockClimateRepository.VerifyGetById(Times.Once());
        }
    }
}
