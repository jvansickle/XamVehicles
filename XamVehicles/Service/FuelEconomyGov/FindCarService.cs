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
                var yearsDict = JsonConvert.DeserializeObject<Dictionary<string,Dictionary<string, int>>>(await result.Content.ReadAsStringAsync());

                var minYear = yearsDict["Years"]["min_year"];
                var maxYear = yearsDict["Years"]["max_year"];

                List<string> years = new List<string>(maxYear - minYear);

                for(int i = minYear; i <= maxYear; i++)
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
                var makesDict = JsonConvert.DeserializeObject<Dictionary<string, List<Make>>>(await result.Content.ReadAsStringAsync());

                var makesList = makesDict["Makes"];

                return makesList;
            }

            return new List<Make>();
        }
    }
}
