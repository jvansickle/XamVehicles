using Xamarin.Forms;
using XamVehicles.ViewModel;

namespace XamVehicles.View
{
    public partial class VehicleSelectionPage : ContentPage
    {
        public VehicleSelectionPage()
        {
            InitializeComponent();
            BindingContext = DependencyService.Get<VehicleSelectionViewModel>();
        }
    }
}
