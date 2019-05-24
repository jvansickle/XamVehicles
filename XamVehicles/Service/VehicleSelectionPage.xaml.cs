using System;
using Xamarin.Forms;
using XamVehicles.ViewModel;

namespace XamVehicles.View
{
    public partial class VehicleSelectionPage : ContentPage
    {
        private VehicleSelectionViewModel ViewModel => BindingContext as VehicleSelectionViewModel;

        public VehicleSelectionPage()
        {
            InitializeComponent();
            BindingContext = DependencyService.Get<VehicleSelectionViewModel>();
        }

        void HandleConfirmClicked(object sender, EventArgs args)
        {
            var carouselPage = new VehicleDetailCarouselPage();

            var basicInfoPage = new VehicleBasicInfoPage
            {
                BindingContext = new VehicleBasicInfoViewModel(ViewModel.SelectedTrim.ModelId, ViewModel.SelectedVehicleModel.Name, ViewModel.SelectedTrim.TrimName)
            };

            carouselPage.Children.Add(basicInfoPage);

            Navigation.PushModalAsync(new NavigationPage(carouselPage));
        }
    }
}
