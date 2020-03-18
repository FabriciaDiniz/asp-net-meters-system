using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LandisDesktopApp
{
    public partial class MainWindow
    {
        public async void readBtn_Click(object sender, RoutedEventArgs e)
        {
            await CollectReadings();
        }

        public void powerOnBtn_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void powerOffBtn_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private Task CollectReadings()
        {
            throw new NotImplementedException();
        }
    }
}
