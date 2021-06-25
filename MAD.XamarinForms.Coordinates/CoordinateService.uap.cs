using MAD.XamarinForms.Coordinates;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

namespace MAD.XamarinForms.Coordinates
{
    public partial class CoordinateService
    {
        Point ConvertPointToView_Native(Element receiver, Point point, Element view)
        {
            var receiverNative = receiver.GetNativeElement();
            var viewNative = view.GetNativeElement();

            if (receiverNative is null
                || viewNative is null)
                return new Point(-1, -1);

            var transform = receiverNative.TransformToVisual(viewNative);
            var nativePoint = transform.TransformPoint(new Windows.Foundation.Point(point.X, point.Y));

            return new Point(nativePoint.X, nativePoint.Y);
        }
    }
}
