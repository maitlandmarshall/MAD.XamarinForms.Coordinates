using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace MAD.XamarinForms.Coordinates
{
    public static partial class ElementExtensions
    {
        public static UIKit.UIView GetNativeView(this Element element)
        {
            UIKit.UIView nativeView;

            if (element is VisualElement visualElement)
            {
                var renderer = Platform.GetRenderer(visualElement);
                nativeView = renderer.NativeView;
            }
            else if (element is ToolbarItem toolbarItem)
            {
                nativeView = GetNativeToolbarItemView(toolbarItem);
            }
            else
            {
                throw new NotSupportedException();
            }

            return nativeView;
        }

        private static UIKit.UIView GetNativeToolbarItemView (ToolbarItem toolbarItem)
        {
            var toolbarItemParent = toolbarItem.Parent as VisualElement;
            var parentRenderer = Platform.GetRenderer(toolbarItemParent);
            var navigationBar = parentRenderer.ViewController.NavigationController.NavigationBar;

            foreach (var i in navigationBar.Items)
            {
                var rightItems = i.RightBarButtonItems ?? new UIKit.UIBarButtonItem[0];
                var leftItems = i.LeftBarButtonItems ?? new UIKit.UIBarButtonItem[0];
                var allItems = rightItems.Concat(leftItems);

                if (i.BackBarButtonItem != null)
                {
                    allItems = allItems.Concat(new[] { i.BackBarButtonItem });
                }

                foreach (var barButtonItem in allItems)
                {
                    var itemField = barButtonItem.GetType().GetField("_item", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                    if (itemField is null)
                        continue;

                    var tbi = itemField.GetValue(barButtonItem);

                    if (tbi == toolbarItem)
                    {
                        return barButtonItem.ValueForKey(new NSString("view")) as UIKit.UIView;
                    }
                }
            }

            return null;    
        }
    }
}
