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
        Point ConvertPointToView_Native(VisualElement receiver, Point point, VisualElement view)
        {
            var receiverRenderer = receiver.GetOrCreateRenderer();
            var viewRenderer = view.GetOrCreateRenderer();

            var transform = receiverRenderer.ContainerElement.TransformToVisual(viewRenderer.ContainerElement);
            var nativePoint = transform.TransformPoint(new Windows.Foundation.Point(point.X, point.Y));

            return new Point(nativePoint.X, nativePoint.Y);
        }
    }
}
