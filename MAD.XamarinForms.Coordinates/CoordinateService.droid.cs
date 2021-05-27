using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MAD.XamarinForms.Coordinates
{
    public partial class CoordinateService
    {
        Point ConvertPointToView_Native(Element receiver, Point point, Element view)
        {
            var receiverNative = receiver.GetNativeView();
            var viewNative = view.GetNativeView();

            int[] receiverPoint = new int[2];
            int[] viewPoint = new int[2];

            receiverNative.GetLocationOnScreen(receiverPoint);
            viewNative.GetLocationOnScreen(viewPoint);

            var result = new Point(receiverPoint[0] - viewPoint[0] + point.X, receiverPoint[1] - viewPoint[1] + point.Y);
            return result;
        }
    }
}
