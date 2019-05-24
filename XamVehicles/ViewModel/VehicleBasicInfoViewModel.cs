using System;
using System.Threading.Tasks;
using XamVehicles.Service.FuelEconomyGov;

namespace XamVehicles.ViewModel
{
    public class VehicleBasicInfoViewModel : ViewModel
    {
        private string _year;
        public string Year
        {
            get => _year;
            set
            {
                _year = value;
                NotifyPropertyChanged();
            }
        }

        private string _make;
        public string Make
        {
            get => _make;
            set
            {
                _make = value;
                NotifyPropertyChanged();
            }
        }

        private string _model;
        public string Model
        {
            get => _model;
            set
            {
                _model = value;
                NotifyPropertyChanged();
            }
        }

        private string _trim;
        public string Trim
        {
            get => _trim;
            set
            {
                _trim = value;
                NotifyPropertyChanged();
            }
        }

        private readonly FindCarService findCarService;
        private readonly int modelId;

        public VehicleBasicInfoViewModel(int modelId, string modelName, string trim)
        {
            findCarService = new FindCarService();
            this.modelId = modelId;
            Model = modelName;
            Trim = trim;
        }

        internal async Task LoadDetails()
        {
            var modelDetails = await findCarService.GetModelDetails(modelId);

            Year = modelDetails.Year;
            Make = modelDetails.MakeDisplay;
        }
    }
}
