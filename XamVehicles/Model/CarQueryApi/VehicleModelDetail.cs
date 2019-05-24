using System.Collections.Generic;

namespace XamVehicles.Model.CarQueryApi
{
    public class VehicleModelDetail : VehicleModel
    {
        public string ModelId { get; set; }
        public string Year { get; set; }
        public string Body { get; set; }
        public string EnginePosition { get; set; }
        public string EngineCC { get; set; }
        public string EngineCylinder { get; set; }
        public string EngineType { get; set; }
        public string EngineValvesPerCylinder { get; set; }
        public string EnginePowerPs { get; set; }
        public string EngineTorqueNm { get; set; }
        public string EngineTorqueRpm { get; set; }
        public string EngineBoreMM { get; set; }
        public string EngineStrokeMM { get; set; }
        public string EngineCompression { get; set; }
        public string EngineFuel { get; set; }
        public string TopSpeedKph { get; set; }
        public string ZeroToOneHundredKph { get; set; }
        public string Drive { get; set; }
        public string TransmissionType { get; set; }
        public string SeatCount { get; set; }
        public string DoorCount { get; set; }
        public string WeightKg { get; set; }
        public string LengthMM { get; set; }
        public string WidthMM { get; set; }
        public string HeightMM { get; set; }
        public string WheelbaseMM { get; set; }
        public string LkmHwy { get; set; }
        public string LkmMixed { get; set; }
        public string LkmCity { get; set; }
        public string FuelCapL { get; set; }
        public bool SoldInUs { get; set; }
        public string EngineL { get; set; }
        public string EngineCI { get; set; }
        public string EnginePowerHP { get; set; }
        public string EnginePowerKw { get; set; }
        public string EngineTorqueLbft { get; set; }
        public string EngineTorqueKgm { get; set; }
        public string TopSpeedMph { get; set; }
        public string WeightLbs { get; set; }
        public string LengthIN { get; set; }
        public string WidthIN { get; set; }
        public string HeightIN { get; set; }
        public string WheelbaseIN { get; set; }
        public string MpgHwy { get; set; }
        public string MpgCity { get; set; }
        public string MpgMixed { get; set; }
        public string FuelCapG { get; set; }
        public string MakeDisplay { get; set; }
        public string MakeCountry { get; set; }
    }
}
