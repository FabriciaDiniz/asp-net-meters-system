using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MetersDesktopApp.Models;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace MetersDesktopApp
{
    public partial class DetalheWindow
    {
        public static string serverResponse = String.Empty;
        public static long kwh;

        PostgreSQL pg = new PostgreSQL();

        public void readBtn_Click(object sender, RoutedEventArgs e)
        {
            Meter meter = this.DataContext as Meter;
            string command = $"read;{meter.ToString()}";

            OpenNewThread(command);
        }

        static void SendCommand(String server, String message)
        {
            try
            {
                Int32 port = 8000;
                TcpClient client = new TcpClient(server, port);
                NetworkStream stream = client.GetStream();

                using (MemoryStream ms = new MemoryStream())
                {
                    // Translate the Message into ASCII.
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                    // Send the message to the connected TcpServer. 
                    stream.Write(data, 0, data.Length);
                    // Bytes Array to receive Server Response.
                    Byte[] res = new Byte[256];
                    // Read the Tcp Server Response Bytes.
                    Int32 bytes = stream.Read(res, 0, res.Length);
                    ms.Write(res, 0, bytes);
                    serverResponse = Encoding.ASCII.GetString(ms.ToArray());
                    MessageBox.Show(serverResponse);
                    Thread.Sleep(2000);

                    stream.Close();
                    client.Close();
                }                   
            }
            catch (Exception e)
            {
                MessageBox.Show($"Exception: {e.ToString()}");
            }
        }
        public void PowerOnBtn_Click(object sender, RoutedEventArgs e)
        {
            Meter meter = this.DataContext as Meter;
            string command = $"pwrOn;{meter.ToString()}";

            OpenNewThread(command);
        }

        public void PowerOffBtn_Click(object sender, RoutedEventArgs e)
        {
            Meter meter = this.DataContext as Meter;
            string command = $"pwrOff;{meter.ToString()}";

            OpenNewThread(command);
        }

        public void OpenNewThread(string command)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                SendCommand("127.0.0.1", command);
            }).Start();
        }
    }
}
