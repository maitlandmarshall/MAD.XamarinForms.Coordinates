using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MAD.XamarinForms.Coordinates
{
    public partial class CoordinateService : ICoordinateService
    {
        public Point ConvertPointToView(Element receiver, Point point, Element view)
        {
            return this.ConvertPointToView_Native(receiver, point, view);
        }
    }
}
