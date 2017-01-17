using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace TitleBarDemo
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // 获取实例
        ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Color_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton r = sender as RadioButton;
            if (r.Name == "Customization")
            {
                // 活动状态
                titleBar.BackgroundColor = Colors.OrangeRed;
                titleBar.ForegroundColor = Colors.White;
                // 非活动状态
                titleBar.InactiveBackgroundColor = Colors.OrangeRed;
                titleBar.InactiveForegroundColor = Colors.Gray;
                // Button 
                titleBar.ButtonBackgroundColor = Colors.OrangeRed;
                titleBar.ButtonForegroundColor = Colors.White;
                // Button 非活动
                titleBar.ButtonInactiveBackgroundColor = Colors.OrangeRed;
                titleBar.ButtonInactiveForegroundColor = Colors.Gray;
                // Button 指针在上
                titleBar.ButtonHoverBackgroundColor = Colors.Red;
                titleBar.ButtonHoverForegroundColor = Colors.White;
                // Button 按下
                titleBar.ButtonPressedBackgroundColor = Colors.Orange;
                titleBar.ButtonPressedForegroundColor = Colors.Black;
            }
            else
            {
                titleBar.BackgroundColor = null;
                titleBar.ForegroundColor = null;
                titleBar.InactiveBackgroundColor = null;
                titleBar.InactiveForegroundColor = null;

                titleBar.ButtonBackgroundColor = null;
                titleBar.ButtonForegroundColor = null;

                titleBar.ButtonHoverBackgroundColor = null;
                titleBar.ButtonHoverForegroundColor = null;

                titleBar.ButtonPressedBackgroundColor = null;
                titleBar.ButtonPressedForegroundColor = null;

                titleBar.ButtonInactiveBackgroundColor = null;
                titleBar.ButtonInactiveForegroundColor = null;
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var view = ApplicationView.GetForCurrentView();
            if (view.IsFullScreenMode)
            {
                view.ExitFullScreenMode();
            }
            else
            {
                if (view.TryEnterFullScreenMode())
                {
                    ;
                }
                else
                {
                    await new MessageDialog("Failed to enter").ShowAsync();
                }
            }
        }

        private void Extend_Toggled(object sender, RoutedEventArgs e)
        {
            if (Extend.IsOn)
            {
                var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
                coreTitleBar.ExtendViewIntoTitleBar = true;
            }
            else
            {
                var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
                coreTitleBar.ExtendViewIntoTitleBar = false;
            }
        }
    }
}
