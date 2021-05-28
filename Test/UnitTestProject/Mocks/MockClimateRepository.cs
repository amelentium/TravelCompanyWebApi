using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Repository.Repository.Interface;

namespace UnitTestProject.Mocks
{
    public class MockClimateRepository : Mock<IClimateRepository>
    {
        public async Task<MockClimateRepository> MockGetAll(IEnumerable<Climate> result)
        {
            Setup(x => x.Get())
                .ReturnsAsync(result);

            return this;
        }

        public MockClimateRepository VerifyGetAll(Times times)
        {
            Verify(x => x.Get(), times);

            return this;
        }
        public async Task<MockClimateRepository> MockGetById(Climate result)
        {
            Setup(x => x.GetById(It.IsAny<byte>()))
                .ReturnsAsync(result);

            return this;
        }

        public MockClimateRepository VerifyGetById(Times times)
        {
            Verify(x => x.GetById(It.IsAny<byte>()), times);

            return this;
        }
    }
}
