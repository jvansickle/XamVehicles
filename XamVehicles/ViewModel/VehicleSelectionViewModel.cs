using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamVehicles.Model.CarQueryApi;
using XamVehicles.Service.FuelEconomyGov;
using XamVehicles.ViewModel;

[assembly:Dependency(typeof(VehicleSelectionViewModel))]
namespace XamVehicles.ViewModel
{
    public class VehicleSelectionViewModel : ViewModel
    {
        private ObservableCollection<int> _years;
        public ObservableCollection<int> Years
        {
            get => _years;
            set
            {
                _years = value;
                NotifyPropertyChanged();
            }
        }

        private int _selectedYear;
        public int SelectedYear
        {
            get => _selectedYear;
            set
            {
                _selectedYear = value;
                NotifyPropertyChanged();

                // Reset collections and reload makes
                Makes.Clear();
                VehicleModels.Clear();
                Trims.Clear();

                SelectedMake = null;
                LoadMakes();
            }
        }

        private ObservableCollection<Make> _makes;
        public ObservableCollection<Make> Makes
        {
            get => _makes;
            set
            {
                _makes = value;
                NotifyPropertyChanged();
            }
        }

        private Make _selectedMake;
        public Make SelectedMake
        {
            get => _selectedMake;
            set
            {
                _selectedMake = value;
                NotifyPropertyChanged();

                // Reset Models and Trims and reload Models
                VehicleModels.Clear();
                Trims.Clear();

                LoadVehicleModels();
            }
        }

        private ObservableCollection<VehicleModel> _vehicleModels;
        public ObservableCollection<VehicleModel> VehicleModels
        {
            get => _vehicleModels;
            set
            {
                _vehicleModels = value;
                NotifyPropertyChanged();
            }
        }

        private VehicleModel _selectedVehicleModel;
        public VehicleModel SelectedVehicleModel
        {
            get => _selectedVehicleModel;
            set
            {
                _selectedVehicleModel = value;
                NotifyPropertyChanged();

                SelectedTrim = null;
                Trims.Clear();

                LoadTrims();
            }
        }

        private ObservableCollection<Trim> _trims;
        public ObservableCollection<Trim> Trims
        {
            get => _trims;
            set
            {
                _trims = value;
                NotifyPropertyChanged();
            }
        }

        private Trim _selectedTrim;
        public Trim SelectedTrim
        {
            get => _selectedTrim;
            set
            {
                _selectedTrim = value;
                NotifyPropertyChanged();
            }
        }

        private readonly FindCarService findCarService;

        public VehicleSelectionViewModel()
        {
            findCarService = new FindCarService();
            LoadYears();
            Makes = new ObservableCollection<Make>();
            VehicleModels = new ObservableCollection<VehicleModel>();
            Trims = new ObservableCollection<Trim>();
        }

        private async Task LoadYears()
        {
            Years = new ObservableCollection<int>(await findCarService.GetYears());
        }

        private async Task LoadMakes()
        {
            Makes = new ObservableCollection<Make>(await findCarService.GetMakes(SelectedYear));
        }

        private async Task LoadVehicleModels()
        {
            if (SelectedMake != null)
            {
                VehicleModels = new ObservableCollection<VehicleModel>(await findCarService.GetModels(SelectedYear, SelectedMake.Id));
            } else
            {
                VehicleModels.Clear();
            }
        }

        private async Task LoadTrims()
        {
            if (SelectedVehicleModel != null)
            {
                Trims = new ObservableCollection<Trim>(await findCarService.GetTrims(SelectedYear, SelectedMake.Id, SelectedVehicleModel.Name));
            } else
            {
                Trims.Clear();
            }
        }
    }
}
