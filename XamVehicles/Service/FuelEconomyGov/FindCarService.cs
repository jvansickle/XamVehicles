using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
                            Name = model["model_name"],
                        };
                    });

                return modelsList;
            }

            return new List<VehicleModel>();
        }

        public async Task<IEnumerable<Trim>> GetTrims(int year, string make, string model)
        {
            var result = await httpClient.GetStringAsync($"{httpRoot}?cmd=getTrims&year={year}&make={make}&model={model}");

            var trimsList = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(result)
                ["Trims"]
                .Select(trim =>
                {
                    return new Trim
                    {
                        ModelId = int.Parse(trim["model_id"]),
                        TrimName = string.IsNullOrWhiteSpace(trim["model_trim"]) ? "Base" : trim["model_trim"]
                    };
                });

            return trimsList;
        }

        public async Task<VehicleModelDetail> GetModelDetails(int modelId)
        {
            var result = await httpClient.GetStringAsync($"{httpRoot}?cmd=getModel&model={modelId}");

            var modelDict = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(result)[0];

            var modelDetail = new VehicleModelDetail
            {
                ModelId = (string)modelDict["model_id"],
                MakeId = (string)modelDict["model_make_id"],
                Name = (string)modelDict["model_name"],
                Year = int.Parse((string)modelDict["model_year"]),
                Body = (string)modelDict["model_body"],
                EnginePosition = (string)modelDict["model_engine_position"],
                EngineCC = int.Parse((string)modelDict["model_engine_cc"]),
                EngineCylinder = int.Parse((string)modelDict["model_engine_cyl"]),
                EngineType = (string)modelDict["model_engine_type"],
                EngineValvesPerCylinder = int.Parse((string)modelDict["model_engine_valves_per_cyl"]),
                EnginePowerPs = int.Parse((string)modelDict["model_engine_power_ps"]),
                EngineTorqueNm = int.Parse((string)modelDict["model_engine_torque_nm"]),
                EngineTorqueRpm = int.Parse((string)modelDict["model_engine_torque_rpm"]),
                EngineBoreMM = double.Parse((string)modelDict["model_engine_bore_mm"]),
                EngineStrokeMM = double.Parse((string)modelDict["model_engine_stroke_mm"]),
                EngineCompression = (string)modelDict["model_engine_compression"],
                EngineFuel = (string)modelDict["model_engine_fuel"],
                TopSpeedKph = int.Parse((string)modelDict["model_top_speed_kph"]),
                ZeroToOneHundredKph = double.Parse((string)modelDict["model_0_to_100_kph"]),
                Drive = (string)modelDict["model_drive"],
                TransmissionType = (string)modelDict["model_transmission_type"],
                SeatCount = int.Parse((string)modelDict["model_seats"]),
                DoorCount = int.Parse((string)modelDict["model_doors"]),
                WeightKg = int.Parse((string)modelDict["model_weight_kg"]),
                LengthMM = int.Parse((string)modelDict["model_length_mm"]),
                WidthMM = int.Parse((string)modelDict["model_width_mm"]),
                HeightMM = int.Parse((string)modelDict["model_height_mm"]),
                WheelbaseMM = int.Parse((string)modelDict["model_wheelbase_mm"]),
                LkmHwy = double.Parse((string)modelDict["model_lkm_hwy"]),
                LkmMixed = double.Parse((string)modelDict["model_lkm_mixed"]),
                LkmCity = double.Parse((string)modelDict["model_lkm_city"]),
                FuelCapL = double.Parse((string)modelDict["model_fuel_cap_l"] ?? ""),
                SoldInUs = (string)modelDict["model_sold_in_us"] == "1",
                EngineL = double.Parse((string)modelDict["model_engine_l"]),
                EngineCI = int.Parse((string)modelDict["model_engine_ci"]),
                EnginePowerHP = int.Parse((string)modelDict["model_engine_power_hp"]),
                EnginePowerKw = int.Parse((string)modelDict["model_engine_power_kw"]),
                EngineTorqueLbft = int.Parse((string)modelDict["model_engine_torque_lbft"]),
                EngineTorqueKgm = int.Parse((string)modelDict["model_engine_torque_kgm"]),
                TopSpeedMph = int.Parse((string)modelDict["model_top_speed_mph"]),
                WeightLbs = int.Parse((string)modelDict["model_weight_lbs"]),
                LengthIN = double.Parse((string)modelDict["model_length_in"]),
                WidthIN = double.Parse((string)modelDict["model_width_in"]),
                HeightIN = double.Parse((string)modelDict["model_height_in"]),
                WheelbaseIN = double.Parse((string)modelDict["model_wheelbase_in"]),
                MpgHwy = int.Parse((string)modelDict["model_mpg_hwy"]),
                MpgCity = int.Parse((string)modelDict["model_mpg_city"]),
                MpgMixed = int.Parse((string)modelDict["model_mpg_mixed"]),
                FuelCapG = double.Parse((string)modelDict["model_fuel_cap_g"]),
                MakeDisplay = (string)modelDict["make_display"],
                MakeCountry = (string)modelDict["make_country"],
            };

            return modelDetail;
        }
    }
}
