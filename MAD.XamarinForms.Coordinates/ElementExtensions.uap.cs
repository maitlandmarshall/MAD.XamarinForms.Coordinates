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
    public static partial class ElementExtensions
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
                var pageContainer = toolbarItem.GetPageContainer();
                parent = (pageContainer as VisualElement).GetOrCreateRenderer().ContainerElement;
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
                if (child is ShellToolbarItemRenderer shellToolbarItemRenderer
                    && shellToolbarItemRenderer.ToolbarItem == toolbarItem)
                {
                    return shellToolbarItemRenderer;
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
