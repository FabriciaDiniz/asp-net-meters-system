using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MetersDesktopApp
{
    public static class TcpClientClass
    {
        public static string Response { get; set; }
        public static void InitializeTcpClient(string message)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                SendCommand("127.0.0.1", message);
            }).Start();
            //new Thread(() =>
            //{
            //    Thread.CurrentThread.IsBackground = true;
            //    Connect("127.0.0.1", "Hello I'm Device 2...");
            //}).Start();
            //Console.ReadLine();
        }
        static void SendCommand(String server, String message)
        {
            try
            {
                Int32 port = 8000;
                TcpClient client = new TcpClient(server, port);
                NetworkStream stream = client.GetStream();

                // Translate the Message into ASCII.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);
                // Bytes Array to receive Server Response.
                Byte[] res = new Byte[256];
                // Read the Tcp Server Response Bytes.
                Int32 bytes = stream.Read(res, 0, res.Length);
                Response = Encoding.ASCII.GetString(res);
                MessageBox.Show(Response);
                Thread.Sleep(2000);

                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Exception: {e.ToString()}");
            }
        }
    }
}
