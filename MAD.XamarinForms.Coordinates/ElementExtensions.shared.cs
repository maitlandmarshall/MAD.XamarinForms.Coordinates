using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MAD.XamarinForms.Coordinates
{
    public static partial class ElementExtensions
    {
        public static Size GetSize(this Element element)
        {
            var sizeService = new SizeService();
            return sizeService.GetSize(element);
        }

        public static Point ConvertPointToView(this Element element, Point point, Element view)
        {
            var coordinateService = new CoordinateService();
            var coordinates = coordinateService.ConvertPointToView(element, point, view);

            return coordinates;
        }

        internal static IPageContainer<Page> GetPageContainer(this Element element)
        {
            // Assume all ToolbarItems must be within a page
            var xamarinParent = element;

            // Go through the parents until you find valid Xamarin root
            do
            {
                xamarinParent = xamarinParent.Parent;
            }
            while (xamarinParent is IPageContainer<Xamarin.Forms.Page> == false);

            return xamarinParent as IPageContainer<Page>;
        }
    }
}
