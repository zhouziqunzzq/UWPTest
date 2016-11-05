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
using System.Net.Http;
using System.Net.Sockets;
using Windows.Storage;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace test
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            var msgDialog = new Windows.UI.Popups.MessageDialog("我是一个提示内容") { Title = "提示标题" };
            msgDialog.Commands.Add(new Windows.UI.Popups.UICommand("确定", uiCommand => { this.tb.Text = $"您点击了：{uiCommand.Label}"; }));
            msgDialog.Commands.Add(new Windows.UI.Popups.UICommand("取消", uiCommand => { this.tb.Text = $"您点击了：{uiCommand.Label}"; }));
            await msgDialog.ShowAsync();
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            resultTB.Text = "Fetching result...";
            var myClient = new HttpClient();
            var myRequest = new HttpRequestMessage
                (HttpMethod.Get, urlTB.Text);
            var response = await myClient.SendAsync(myRequest);
            var content = response.Content;
            string strContent = await content.ReadAsStringAsync();
            var msgDialog = new Windows.UI.Popups.MessageDialog(strContent);
            resultTB.Text = strContent;
            msgDialog.Commands.Add(new Windows.UI.Popups.UICommand("确定", uiCommand => { this.tb.Text = $"您点击了：{uiCommand.Label}"; }));
            await msgDialog.ShowAsync();
        }
    }
}
