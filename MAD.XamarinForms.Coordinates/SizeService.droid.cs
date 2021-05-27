using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace MAD.XamarinForms.Coordinates
{
    public partial class SizeService
    {
        Size GetSize_Native(Element element)
        {
            var nativeView = element.GetNativeView();

            if (nativeView is null)
            {
                return new Xamarin.Forms.Size(-1, -1);
            }

            var width = nativeView.MeasuredWidth;
            var height = nativeView.MeasuredHeight;

            return new Xamarin.Forms.Size(nativeView.Context.FromPixels(width), nativeView.Context.FromPixels(height));
        }
    }
}
