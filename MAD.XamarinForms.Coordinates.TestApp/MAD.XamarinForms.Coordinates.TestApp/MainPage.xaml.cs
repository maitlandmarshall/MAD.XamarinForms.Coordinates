using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MAD.XamarinForms.Coordinates.TestApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var sizeService = new SizeService();
            var coordinateService = new CoordinateService();
            var bounds = sizeService.GetSize(this.tbHi);
            var coords = coordinateService.ConvertPointToView(this.tbHi, Point.Zero, this);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var coordinateService = new CoordinateService();

            var topLeftPoint = coordinateService.ConvertPointToView(this.tpLeft, Point.Zero, this.abs);
            var topRightPoint = coordinateService.ConvertPointToView(this.tpRight, Point.Zero, this.abs);

            var bottomRightPoint = coordinateService.ConvertPointToView(this.btmRight, Point.Zero, this.abs);
            var bottomLeftPoint = coordinateService.ConvertPointToView(this.btmLeft, Point.Zero, this.abs);

            Debug.WriteLine(bottomRightPoint);
        }
    }
}
