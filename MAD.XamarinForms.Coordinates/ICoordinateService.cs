using System;
using Xamarin.Forms;

namespace MAD.XamarinForms.Coordinates
{
    public interface ICoordinateService
    {
        Point ConvertPointToView(Element receiver, Point point, Element view);
    }
}
