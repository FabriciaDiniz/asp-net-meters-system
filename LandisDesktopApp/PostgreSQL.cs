using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Threading.Tasks;
using System.Windows;
using LandisDesktopApp.Models;

namespace LandisDesktopApp
{
    public class PostgreSQL
    {
        public List<Meter> meters = new List<Meter>();

        public List<Meter> GetAllMeters()
        {
            try
            {
                string connstring = "Server=localhost; Port=5432; User Id=admin; Password=1234; Database=Landis;";
                NpgsqlConnection connection = new NpgsqlConnection(connstring);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM public.meters", connection);
                NpgsqlDataReader dataReader = command.ExecuteReader();
                for (int i = 0; dataReader.Read(); i++)
                {
                    Meter meter = new Meter();
                    meter.Id = (long)dataReader[0];
                    meter.Cp = dataReader[1].ToString();
                    meter.IdCs = (int)dataReader[2];
                    meter.TrafoId = dataReader[3].ToString();
                    
                    meters.Add(meter);
                }
                connection.Close();

                return meters;
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
                throw;
            }
        }
    }
}