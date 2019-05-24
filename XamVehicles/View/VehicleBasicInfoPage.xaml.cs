using Xamarin.Forms;
using XamVehicles.ViewModel;

namespace XamVehicles.View
{
    public partial class VehicleBasicInfoPage : ContentPage
    {
        public VehicleBasicInfoPage()
        {
            InitializeComponent();
        }

        protected override async void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is VehicleBasicInfoViewModel vm)
            {
                await vm.LoadDetails();
            }
        }
    }
}
