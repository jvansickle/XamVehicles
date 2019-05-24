using System;
using Xamarin.Forms;

namespace XamVehicles.View
{
    public partial class VehicleDetailCarouselPage : CarouselPage
    {
        public VehicleDetailCarouselPage()
        {
            InitializeComponent();
        }

        void DoneClicked(object sender, EventArgs args)
        {
            Navigation.PopModalAsync();
        }
    }
}
