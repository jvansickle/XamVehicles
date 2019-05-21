using System.Linq;
using XamVehicles.Service.FuelEconomyGov;
using Xunit;

namespace XamVehicles.Test.Service.FuelEconomyGov
{
    public class FindCarServiceTest
    {
        private readonly FindCarService findCarService;

        public FindCarServiceTest()
        {
            findCarService = new FindCarService();
        }

        [Fact]
        public async void GetYears_ReturnsNonEmptySet_Success()
        {
            var result = await findCarService.GetYears();
            Assert.NotEmpty(result);
        }

        [Fact]
        public async void GetYears_ContainsAYear_Success()
        {
            var result = await findCarService.GetYears();
            Assert.Contains("2018", result);
        }

        [Fact]
        public async void GetMakes_NonEmpty_Success()
        {
            var result = await findCarService.GetMakes(2000);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async void GetMakes_Empty_Success()
        {
            var result = await findCarService.GetMakes(1600);
            Assert.Empty(result);
        }

        [Fact]
        public async void GetMakes_NonNullItems_Success()
        {
            var result = await findCarService.GetMakes(2000);
            Assert.NotNull(result.ToList()[0]);
        }
    }
}
