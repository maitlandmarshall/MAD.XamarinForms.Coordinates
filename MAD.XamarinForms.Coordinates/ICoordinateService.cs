using System;
using Xamarin.Forms;

namespace MAD.XamarinForms.Coordinates
{
    public interface ICoordinateService
    {
        Point ConvertPointToView(VisualElement receiver, Point point, VisualElement view);
    }
}
