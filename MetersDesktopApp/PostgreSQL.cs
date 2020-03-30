using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Threading.Tasks;
using System.Windows;
using MetersDesktopApp.Models;

namespace MetersDesktopApp
{
    public class PostgreSQL
    {
        public List<Meter> meters = new List<Meter>();
        MetersDbContext db = new MetersDbContext();

        public void AddMeter(Meter meter)
        {
            db.Add(meter);
            db.SaveChanges();
        }

        public List<Meter> GetAllMeters()
        {
            try
            {
                return db.Meters.ToList<Meter>();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
                throw;
            }
        }

        public long CollectReadings(long meterId)
        {
            Meter meter = db.Meters.Single<Meter>(m => m.Id == meterId);

            //criar uma string para ser enviada, obter um stream
            //transformar o texto para bytes
            //"write" no stream
            //"ler" a resposta que vem do stream

            string req = "read;" + meter.ToString();
            TcpClientClass.InitializeTcpClient(req);
            string response = TcpClientClass.Response;
            MessageBox.Show(response);

            return 1L;
        }
    }
}