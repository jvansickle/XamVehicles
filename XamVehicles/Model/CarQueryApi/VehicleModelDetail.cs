using System.Collections.Generic;

namespace XamVehicles.Model.CarQueryApi
{
    public class VehicleModelDetail : VehicleModel
    {
        public string ModelId { get; set; }
        public int Year { get; set; }
        public string Body { get; set; }
        public string EnginePosition { get; set; }
        public int EngineCC { get; set; }
        public int EngineCylinder { get; set; }
        public string EngineType { get; set; }
        public int EngineValvesPerCylinder { get; set; }
        public int EnginePowerPs { get; set; }
        public int EngineTorqueNm { get; set; }
        public int EngineTorqueRpm { get; set; }
        public double EngineBoreMM { get; set; }
        public double EngineStrokeMM { get; set; }
        public string EngineCompression { get; set; }
        public string EngineFuel { get; set; }
        public int TopSpeedKph { get; set; }
        public double ZeroToOneHundredKph { get; set; }
        public string Drive { get; set; }
        public string TransmissionType { get; set; }
        public int SeatCount { get; set; }
        public int DoorCount { get; set; }
        public int WeightKg { get; set; }
        public int LengthMM { get; set; }
        public int WidthMM { get; set; }
        public int HeightMM { get; set; }
        public int WheelbaseMM { get; set; }
        public double LkmHwy { get; set; }
        public double LkmMixed { get; set; }
        public double LkmCity { get; set; }
        public double FuelCapL { get; set; }
        public bool SoldInUs { get; set; }
        public double EngineL { get; set; }
        public int EngineCI { get; set; }
        public int EnginePowerHP { get; set; }
        public int EnginePowerKw { get; set; }
        public int EngineTorqueLbft { get; set; }
        public int EngineTorqueKgm { get; set; }
        public int TopSpeedMph { get; set; }
        public int WeightLbs { get; set; }
        public double LengthIN { get; set; }
        public double WidthIN { get; set; }
        public double HeightIN { get; set; }
        public double WheelbaseIN { get; set; }
        public int MpgHwy { get; set; }
        public int MpgCity { get; set; }
        public int MpgMixed { get; set; }
        public double FuelCapG { get; set; }
        public string MakeDisplay { get; set; }
        public string MakeCountry { get; set; }
    }
}
