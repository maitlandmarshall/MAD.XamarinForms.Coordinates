using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MAD.XamarinForms.Coordinates
{
    public partial class SizeService : ISizeService
    {
        public Size GetSize(Element element)
        {
            return this.GetSize_Native(element);
        }
    }
}
