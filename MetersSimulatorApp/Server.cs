using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows;
using MetersSimulatorApp.Models;

namespace MetersSimulatorApp
{
    class Server
    {
        TcpListener server = null;
        public Server(string ip, int port)
        {
            IPAddress localAddr = IPAddress.Parse(ip);
            server = new TcpListener(localAddr, port);
            server.Start();
            StartListener();
        }
        public void StartListener()
        {
            try
            {
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    //Console.WriteLine("Connected!");
                    Thread t = new Thread(new ParameterizedThreadStart(HandleDevice));
                    t.Start(client);
                }
            }
            catch (SocketException e)
            {
                MessageBox.Show($"SocketException: {e.ToString()}");
                server.Stop();
            }
        }
        public void HandleDevice(Object obj)
        {
            TcpClient client = (TcpClient)obj;
            var stream = client.GetStream();
            string imei = String.Empty;
            string data = null;
            Byte[] bytes = new Byte[256];
            int i;
            string meterData = String.Empty;
            try
            {
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    string hex = BitConverter.ToString(bytes);
                    data = Encoding.ASCII.GetString(bytes, 0, i);
                    if (data.StartsWith("read;"))
                    {
                        meterData = data.Substring(5);
                        Meter meter = new Meter(meterData);

                        string valueRead = meter.Kwh.ToString();
                        Byte[] reply = System.Text.Encoding.ASCII.GetBytes(valueRead);
                        stream.Write(reply, 0, reply.Length);
                    } 
                    else if(data.StartsWith("pwrOn;"))
                    {
                        meterData = data.Substring(6);
                        Meter meter = new Meter(meterData);
                        string str;

                        if(!meter.IsOn)
                        {
                            meter.IsOn = true;
                            str = $"Meter status: on; (IsOn {meter.IsOn.ToString()})";
                        }
                        else
                        {
                            str = $"Meter already on";
                        }

                        Byte[] reply = System.Text.Encoding.ASCII.GetBytes(str);
                        stream.Write(reply, 0, reply.Length);
                    } 
                    else if(data.StartsWith("pwrOff;"))
                    {
                        meterData = data.Substring(7);
                        Meter meter = new Meter(meterData);
                        string str;

                        if (meter.IsOn)
                        {
                            meter.IsOn = false;
                            str = $"Meter status: off; (IsOn {meter.IsOn.ToString()})";
                        }
                        else
                        {
                            str = $"Meter already off";
                        }

                        Byte[] reply = System.Text.Encoding.ASCII.GetBytes(str);
                        stream.Write(reply, 0, reply.Length);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Exception: {e.ToString()}");
                client.Close();
            }

        }
    }
}