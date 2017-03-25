using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace ContentDialogDemo
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Style transparent = (Style)Application.Current.Resources["TransparentDialog"];

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Raw_Click(object sender, RoutedEventArgs e)
        {
            var contentDialog = new ContentDialog()
            {
                Content = new Content("This is a raw ContentDialog."),
                PrimaryButtonText = "确定",
                FullSizeDesired = false
            };

            contentDialog.PrimaryButtonClick += (_s, _e) =>
            {
                contentDialog.Hide();
            };
            await contentDialog.ShowAsync();
        }

        private async void Transparent_Click(object sender, RoutedEventArgs e)
        {
            var contentDialog = new ContentDialog()
            {
                Content = new Content("This is a transparent ContentDialog."),
                PrimaryButtonText = "确定",
                FullSizeDesired = false
            };

            contentDialog.Style = transparent;

            contentDialog.PrimaryButtonClick += (_s, _e) =>
            {
                contentDialog.Hide();
            };
            await contentDialog.ShowAsync();
        }
    }
}
