using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

namespace MAD.XamarinForms.Coordinates
{
    public static class ElementExtensions
    {
        public static UIElement GetNativeElement(this Element element)
        {
            UIElement nativeElement;

            if (element is VisualElement visualElement)
            {
                nativeElement = visualElement.GetOrCreateRenderer().ContainerElement;
            }
            else if (element is ToolbarItem toolbarItem)
            {
                nativeElement = GetNativeToolbarItemElement(toolbarItem);
            }
            else
            {
                throw new NotSupportedException();
            }

            return nativeElement;
        }

        private static UIElement GetNativeToolbarItemElement(ToolbarItem toolbarItem, DependencyObject parent = null)
        {
            if (parent is null)
            {
                // Assume all ToolbarItems must be within a page
                var page = toolbarItem.Parent as Xamarin.Forms.Page;

                // Get the renderer
                var nativePage = page.GetOrCreateRenderer().ContainerElement;

                // Go through the parents until you find a native control
                do
                {
                    parent = nativePage.Parent;
                } 
                while (parent is IVisualElementRenderer);
            }
            
            var childrenCount = VisualTreeHelper.GetChildrenCount(parent);

            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child is CommandBar commandBar)
                {
                    var allCommandBarElements = commandBar.PrimaryCommands.Union(commandBar.SecondaryCommands);

                    foreach (var cbe in allCommandBarElements)
                    {
                        if (cbe is FrameworkElement frameworkElement
                            && frameworkElement.DataContext == toolbarItem)
                        {
                            return frameworkElement;
                        }
                    }
                }
                else
                {
                    var innerResult = GetNativeToolbarItemElement(toolbarItem, child);

                    if (innerResult != null)
                        return innerResult;
                }
            }

            return null;
        }

        
    }
}
