using Android.Content;
using Android.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

namespace MAD.XamarinForms.Coordinates
{
    public static partial class ElementExtensions
    {
        public static Android.Views.View GetNativeView(this Element element)
        {
            Android.Views.View nativeView;

            if (element is VisualElement visualElement)
            {
                var renderer = Platform.GetRenderer(visualElement);
                nativeView = renderer.View;
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

        private static Android.Views.View GetNativeToolbarItemView (ToolbarItem toolbarItem)
        {
            var toolbarItemParent = toolbarItem.Parent as Page;
            var pageContainer = toolbarItem.GetPageContainer();
            var pageContainerRenderer = Platform.GetRenderer(pageContainer as VisualElement);

            var androidContext = pageContainerRenderer.View.Context;
            var fragmentManager = androidContext.GetFragmentManager();
            var fragments = fragmentManager.Fragments;

            foreach (var f in fragments)
            {
                if (f is ShellItemRenderer shellItemRenderer)
                {                    
                    var shellItem = shellItemRenderer.ShellItemController as ShellItem;
                    var shellSection = shellItem.CurrentItem;
                    var shellContent = shellSection.CurrentItem;
                    var page = shellContent.Content;

                    if (page == toolbarItemParent)
                    {
                        var shellSectionRenderer = GetPrivateFieldValue<ShellSectionRenderer>(shellItemRenderer, "_currentFragment");
                        var toolbarTracker = GetPrivateFieldValue<ShellToolbarTracker>(shellSectionRenderer, "_toolbarTracker");
                        var currentMenuItems = GetPrivateFieldValue<IList<IMenuItem>>(toolbarTracker, "_currentMenuItems");
                        var currentToolbarItems = GetPrivateFieldValue<IList<ToolbarItem>>(toolbarTracker, "_currentToolbarItems");

                        var toolbarItemIdx = currentToolbarItems.IndexOf(toolbarItem);
                        var menuItem = currentMenuItems.ElementAt(toolbarItemIdx);

                        var toolbar = GetPrivateFieldValue<AndroidX.AppCompat.Widget.Toolbar>(toolbarTracker, "_toolbar");
                        var toolbarChildCount = toolbar.ChildCount;

                        for (int i = 0; i < toolbarChildCount; i++)
                        {
                            var toolbarChild = toolbar.GetChildAt(i);

                            if (toolbarChild is AndroidX.AppCompat.Widget.ActionMenuView actionMenuView)
                            {
                                var actionMenuChildCount = actionMenuView.ChildCount;

                                for (int x = 0; x < actionMenuChildCount; x++)
                                {
                                    var actionMenuChild = actionMenuView.GetChildAt(x);

                                    if (actionMenuChild.Id == menuItem.ItemId)
                                    {
                                        return actionMenuChild;
                                    }
                                }

                            }
                        }
                    }
                }
            }

            return null;
        }

        private static TResult GetPrivateFieldValue<TResult>(object obj, string fieldName)
        {
            var type = obj.GetType();
            var bindingFlags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic;
            var field = type.GetField(fieldName, bindingFlags) ?? type.BaseType.GetField(fieldName, bindingFlags);

            return (TResult)field.GetValue(obj);
        }
    }
}
