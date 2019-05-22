using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamVehicles.Model.CarQueryApi;

namespace XamVehicles.Service.FuelEconomyGov
{
    /*
     * http://www.carqueryapi.com/documentation/api-usage/
     */
    public class FindCarService
    {
        private HttpClient httpClient = new HttpClient();

        private static string httpRoot = "https://www.carqueryapi.com/api/0.3/";

        public async Task<IEnumerable<string>> GetYears()
        {
            var result = await httpClient.GetAsync($"{httpRoot}?cmd=getYears");

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var yearsDict = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, int>>>(await result.Content.ReadAsStringAsync());

                var minYear = yearsDict["Years"]["min_year"];
                var maxYear = yearsDict["Years"]["max_year"];

                List<string> years = new List<string>(maxYear - minYear);

                for (int i = minYear; i <= maxYear; i++)
                {
                    years.Add(i.ToString());
                }

                return years;
            }

            return new List<string>();
        }

        public async Task<IEnumerable<Make>> GetMakes(int year)
        {
            var result = await httpClient.GetAsync($"{httpRoot}?cmd=getMakes&year={year}");

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var makesList = JsonConvert
                    .DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(await result.Content.ReadAsStringAsync())
                    ["Makes"]
                    .Select(make =>
                    {
                        return new Make
                        {
                            Id = make["make_id"],
                            DisplayText = make["make_display"],
                            IsCommon = make["make_is_common"] == "1",
                            Country = make["make_country"]
                        };
                    });

                return makesList;
            }

            return new List<Make>();
        }

        public async Task<IEnumerable<VehicleModel>> GetModels(int year, string makeId)
        {
            var result = await httpClient.GetAsync($"{httpRoot}?cmd=getModels&make={makeId}&year={year}");

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var modelsList = JsonConvert
                    .DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(await result.Content.ReadAsStringAsync())
                    ["Models"]
                    .Select(model =>
                    {
                        return new VehicleModel
                        {
                            MakeId = model["model_make_id"],
                            Name = model["model_name"]
                        };
                    });

                return modelsList;
            }

            return new List<VehicleModel>();
        }
    }
}
