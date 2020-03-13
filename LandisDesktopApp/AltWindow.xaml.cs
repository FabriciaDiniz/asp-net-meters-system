//using Microsoft.AspNetCore.SignalR.Client;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
//using LandisDesktopApp.Properties;

//namespace LandisDesktopApp
//{
//    /// <summary>
//    /// Interação lógica para MainWindow.xam
//    /// </summary>
//    public partial class AltWindow : Window
//    {
//        HubConnection _connection;

//        public AltWindow()
//        {
//            InitializeComponent();
//        }

//        public async void ConnectBtn_Click(object sender, RoutedEventArgs e)
//        {
//            InitializeConnection();
//            try
//            {
//                await _connection.StartAsync();
//                messagesList.Items.Add("Connection started");
//                ConnectionTextBox.Text = _connection.State.ToString();

//                connectBtn.IsEnabled = false;
//                EnableCommandButtons();
//            }
//            catch (Exception ex)
//            {
//                messagesList.Items.Add(_connection.State);
//                messagesList.Items.Add(ex.Message);
//                messagesList.Items.Add(ex.StackTrace);
//            }

//            _connection.On<string, string>("ReceiveMessage", (user, message) =>
//            {
//                this.Dispatcher.Invoke(() =>
//                {
//                    var newMessage = $"{user}: {message}";
//                    messagesList.Items.Add(newMessage);
//                });
//            });

//            _connection.On<string>("Posted", (value) =>
//            {
//                this.Dispatcher.BeginInvoke((Action)(() =>
//                {
//                    messagesList.Items.Add(value);
//                }));
//            });
//        }

//        private void InitializeConnection()
//        {
//            _connection = new HubConnectionBuilder()
//                            .WithUrl("http://localhost:64698/TestHub")
//                            .Build();

//            _connection.Closed += async (error) =>
//            {
//                await Task.Delay(new Random().Next(0, 5) * 1000);
//                await _connection.StartAsync();
//            };

//            _connection.Reconnecting += error =>
//            {
//                Debug.Assert(_connection.State == HubConnectionState.Reconnecting);

//                // Notify users the connection was lost and the client is reconnecting.
//                // Start queuing or dropping messages.

//                return Task.CompletedTask;
//            };
//        }

//        private void EnableCommandButtons()
//        {
//            readBtn.IsEnabled = true;
//            powerOffBtn.IsEnabled = true;
//            powerOnBtn.IsEnabled = true;
//        }
//    }
//}
