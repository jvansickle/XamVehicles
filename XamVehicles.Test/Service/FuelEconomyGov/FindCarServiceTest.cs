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
            Assert.Contains(2018, result);
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

        [Fact]
        public async void GetMakes_NonNullProperties_Success()
        {
            var result = await findCarService.GetMakes(2000);
            var model = result.ToList()[0];
            model.GetType().GetProperties().ToList().ForEach(p =>
            {
                Assert.NotNull(p.GetValue(model));
            });
        }

        [Fact]
        public async void GetModels_NonEmpty_Success()
        {
            var result = await findCarService.GetModels(2000, "ford");
            Assert.NotEmpty(result);
        }

        [Fact]
        public async void GetModels_OutOfRange_YieldsEmpty()
        {
            var result = await findCarService.GetModels(100, "ford");
            Assert.Empty(result);
        }

        [Fact]
        public async void GetModels_NonNull_Success()
        {
            var result = await findCarService.GetModels(2000, "ford");
            Assert.NotNull(result.ToList()[0]);
        }

        [Fact]
        public async void GetModels_PropertiesNonNull_Success()
        {
            var result = await findCarService.GetModels(2000, "ford");
            var model = result.ToList()[0];

            model.GetType().GetProperties().ToList().ForEach(p =>
            {
                Assert.NotNull(p.GetValue(model));
            });
        }

        [Fact]
        public async void GetTrims_NonEmpty_Success()
        {
            var result = await findCarService.GetTrims(2019, "subaru", "wrx");
            Assert.NotEmpty(result);
        }

        [Fact]
        public async void GetTrims_PropertiesNonNull_Success()
        {
            var result = await findCarService.GetTrims(2019, "subaru", "wrx");

            var trim = result.ToList()[0];
            trim.GetType().GetProperties().ToList().ForEach(p =>
            {
                Assert.NotNull(p.GetValue(trim));
            });
        }

        [Fact]
        public async void GetModelDetails_ValidId_NonNullValues()
        {
            var result = await findCarService.GetModelDetails(11459);
            Assert.NotNull(result.ModelId);
        }
    }
}
