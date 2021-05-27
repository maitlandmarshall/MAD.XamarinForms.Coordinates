using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

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

            return new Xamarin.Forms.Size(width, height);
        }
    }
}
