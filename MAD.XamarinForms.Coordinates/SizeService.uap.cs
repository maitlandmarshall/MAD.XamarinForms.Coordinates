using Windows.Foundation;
using Xamarin.Forms;

namespace MAD.XamarinForms.Coordinates
{
    public partial class SizeService
    {
        private Xamarin.Forms.Size GetSize_Native(Element element)
        {
            var nativeElement = element.GetNativeElement();

            if (nativeElement is null)
            {
                return new Xamarin.Forms.Size(-1, -1);
            }

            var size = nativeElement.DesiredSize;

            return new Xamarin.Forms.Size(size.Width, size.Height);
        }
    }
}
