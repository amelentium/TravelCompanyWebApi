using Moq;
using TravelCompanyWebApi.Repository.Repository.Interface;
using TravelCompanyWebApi.Repository.UnitOfWork.Interface;

namespace UnitTestProject.Mocks
{
    class MockUnitOfWork : Mock<IUnitOfWork>
    {
        public MockUnitOfWork MockGetClimateRepository(IClimateRepository result)
        {
            Setup(x => x.ClimateRepository)
                .Returns(result);

            return this;
        }

        public MockUnitOfWork VerifyGetClimateRepository(Times times)
        {
            Verify(x => x.ClimateRepository, times);

            return this;
        }
    }
}
