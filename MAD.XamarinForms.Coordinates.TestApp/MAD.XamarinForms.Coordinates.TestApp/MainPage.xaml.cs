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
            var bounds = this.tbHi.GetSize();
            var coords = this.tbHi.ConvertPointToView(Point.Zero, this);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var topLeftPoint = this.tpLeft.ConvertPointToView(Point.Zero, this.abs);
            var topRightPoint = this.tpRight.ConvertPointToView(Point.Zero, this.abs);

            var bottomRightPoint = this.btmRight.ConvertPointToView(Point.Zero, this.abs);
            var bottomLeftPoint = this.btmLeft.ConvertPointToView(Point.Zero, this.abs);

            Debug.WriteLine(bottomRightPoint);
        }
    }
}
