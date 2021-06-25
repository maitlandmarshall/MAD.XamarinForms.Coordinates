using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace MAD.XamarinForms.Coordinates
{
    public partial class CoordinateService
    {
        Point ConvertPointToView_Native(Element receiver, Point point, Element view)
        {
            var receiverNative = receiver.GetNativeView();
            var viewNative = view.GetNativeView();

            if (receiverNative is null
                || viewNative is null)
                return new Point(-1, -1);

            var nativePoint = receiverNative.ConvertPointToView(new CoreGraphics.CGPoint(point.X, point.Y), viewNative);

            return new Point(nativePoint.X, nativePoint.Y);
        }
    }
}
