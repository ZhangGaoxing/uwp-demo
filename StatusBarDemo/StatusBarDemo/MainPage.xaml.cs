using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.ViewManagement;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.Xaml.Media;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace StatusBarDemo
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        StatusBar statusBar;
        // 获取系统当前颜色
        SolidColorBrush accentColor = (SolidColorBrush)Application.Current.Resources["SystemControlBackgroundAccentBrush"];

        public MainPage()
        {
            // 判断是否存在 StatusBar
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                statusBar = StatusBar.GetForCurrentView();
            }
            else
            {
                Application.Current.Exit();
            }

            this.InitializeComponent();
        }

        private async void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton r = sender as RadioButton;

            if (r.Name == "Show")
            {
                await statusBar.ShowAsync(); 
            }
            else
            {
                await statusBar.HideAsync();
            }
        }

        private void Color_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton r = sender as RadioButton;

            if (r.Name == "Black")
            {
                statusBar.BackgroundColor = Colors.Black;
                statusBar.ForegroundColor = Colors.White;  
            }
            else if(r.Name == "White")
            {
                statusBar.BackgroundColor = Colors.White;
                statusBar.ForegroundColor = Colors.Black;
                statusBar.BackgroundOpacity = 1;
            }
            else
            {
                statusBar.BackgroundColor = accentColor.Color;
                statusBar.ForegroundColor = Colors.Black;
                statusBar.BackgroundOpacity = 1;
            }
        }

        private void Opacity_ValueChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            statusBar.BackgroundOpacity = Opacity.Value / 10;
        }
    }
}
